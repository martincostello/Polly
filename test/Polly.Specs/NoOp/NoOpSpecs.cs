namespace Polly.Specs.NoOp;

public class NoOpSpecs
{
    [Fact]
    public void Should_throw_when_action_is_null()
    {
        var flags = BindingFlags.NonPublic | BindingFlags.Instance;
        Func<Context, CancellationToken, EmptyStruct> action = null!;

        var instance = Activator.CreateInstance(typeof(NoOpPolicy), true)!;
        var instanceType = instance.GetType();
        var methods = instanceType.GetMethods(flags);

        var methodInfo = methods.First(method => method is { Name: "Implementation", ReturnType.Name: "TResult" });
        var generic = methodInfo.MakeGenericMethod(typeof(EmptyStruct));
        var func = () => generic.Invoke(instance, [action, new Context(), CancellationToken.None]);

        var exceptionAssertions = func.Should.Throw<TargetInvocationException>();
        exceptionAssertions.And.Message.ShouldBe("Exception has been thrown by the target of an invocation.");
        exceptionAssertions.And.InnerException.ShouldBeOfType<ArgumentNullException>()
            .Which.ParamName.ShouldBe("action");
    }

    [Fact]
    public void Should_execute_user_delegate()
    {
        NoOpPolicy policy = Policy.NoOp();
        bool executed = false;

        policy.Invoking(x => x.Execute(() => { executed = true; }))
            .Should.NotThrow();

        executed.ShouldBeTrue();
    }

    [Fact]
    public void Should_execute_user_delegate_without_adding_extra_cancellation_behaviour()
    {
        NoOpPolicy policy = Policy.NoOp();
        bool executed = false;

        using (var cts = new CancellationTokenSource())
        {
            cts.Cancel();

            policy.Invoking(p => p.Execute(_ => { executed = true; }, cts.Token))
                .Should.NotThrow();
        }

        executed.ShouldBeTrue();
    }
}
