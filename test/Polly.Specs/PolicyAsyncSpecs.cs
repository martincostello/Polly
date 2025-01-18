namespace Polly.Specs;

public class PolicyAsyncSpecs
{
    #region Execute tests

    [Fact]
    public async Task Executing_the_policy_action_should_execute_the_specified_async_action()
    {
        bool executed = false;

        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { });

        await policy.ExecuteAsync(() =>
        {
            executed = true;
            return TaskHelper.EmptyTask;
        });

        executed.ShouldBeTrue();
    }

    [Fact]
    public async Task Executing_the_policy_function_should_execute_the_specified_async_function_and_return_the_result()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { });

        int result = await policy.ExecuteAsync(() => Task.FromResult(2));

        result.ShouldBe(2);
    }

    #endregion

    #region ExecuteAndCapture tests

    [Fact]
    public async Task Executing_the_policy_action_successfully_should_return_success_result()
    {
        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync(() => TaskHelper.EmptyTask);

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Successful,
            FinalException = (Exception?)null,
            ExceptionType = (ExceptionType?)null,
        });
    }

    [Fact]
    public async Task Executing_the_policy_action_and_failing_with_a_handled_exception_type_should_return_failure_result_indicating_that_exception_type_is_one_handled_by_this_policy()
    {
        var handledException = new DivideByZeroException();

        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync(() => throw handledException);

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Failure,
            FinalException = handledException,
            ExceptionType = ExceptionType.HandledByThisPolicy,
        });
    }

    [Fact]
    public async Task Executing_the_policy_action_and_failing_with_an_unhandled_exception_type_should_return_failure_result_indicating_that_exception_type_is_unhandled_by_this_policy()
    {
        var unhandledException = new Exception();

        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync(() => throw unhandledException);

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Failure,
            FinalException = unhandledException,
            ExceptionType = ExceptionType.Unhandled
        });
    }

    [Fact]
    public async Task Executing_the_policy_function_successfully_should_return_success_result()
    {
        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync(() => Task.FromResult(int.MaxValue));

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Successful,
            FinalException = (Exception?)null,
            ExceptionType = (ExceptionType?)null,
            FaultType = (FaultType?)null,
            FinalHandledResult = default(int),
            Result = int.MaxValue
        });
    }

    [Fact]
    public async Task Executing_the_policy_function_and_failing_with_a_handled_exception_type_should_return_failure_result_indicating_that_exception_type_is_one_handled_by_this_policy()
    {
        var handledException = new DivideByZeroException();

        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync<int>(() => throw handledException);

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Failure,
            FinalException = handledException,
            ExceptionType = ExceptionType.HandledByThisPolicy,
            FaultType = FaultType.ExceptionHandledByThisPolicy,
            FinalHandledResult = default(int),
            Result = default(int)
        });
    }

    [Fact]
    public async Task Executing_the_policy_function_and_failing_with_an_unhandled_exception_type_should_return_failure_result_indicating_that_exception_type_is_unhandled_by_this_policy()
    {
        var unhandledException = new Exception();

        var result = await Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _) => { })
            .ExecuteAndCaptureAsync<int>(() => throw unhandledException);

        result.ShouldBeEquivalentTo(new
        {
            Outcome = OutcomeType.Failure,
            FinalException = unhandledException,
            ExceptionType = ExceptionType.Unhandled,
            FaultType = FaultType.UnhandledException,
            FinalHandledResult = default(int),
            Result = default(int)
        });
    }

    #endregion

    #region Context tests

    [Fact]
    public async Task Executing_the_policy_action_should_throw_when_context_data_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAsync(_ => TaskHelper.EmptyTask, (IDictionary<string, object>)null!));
    }

    [Fact]
    public async Task Executing_the_policy_action_should_throw_when_context_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        var ex = await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAsync(_ => TaskHelper.EmptyTask, null!));
        ex.ParamName.ShouldBe("context");
    }

    [Fact]
    public async Task Executing_the_policy_function_should_throw_when_context_data_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAsync(_ => Task.FromResult(2), (IDictionary<string, object>)null!));
    }

    [Fact]
    public async Task Executing_the_policy_function_should_throw_when_context_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        var ex = await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAsync(_ => Task.FromResult(2), null!));
        ex.ParamName.ShouldBe("context");
    }

    [Fact]
    public async Task Executing_the_policy_function_should_pass_context_to_executed_delegate()
    {
        string operationKey = "SomeKey";
        Context executionContext = new Context(operationKey);
        Context? capturedContext = null;

        var policy = Policy.NoOpAsync();

        await policy.ExecuteAsync(context => { capturedContext = context; return TaskHelper.EmptyTask; }, executionContext);

        capturedContext.ShouldBeSameAs(executionContext);
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_action_should_throw_when_context_data_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAndCaptureAsync(_ => TaskHelper.EmptyTask, (IDictionary<string, object>)null!));
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_action_should_throw_when_context_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        var ex = await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAndCaptureAsync(_ => TaskHelper.EmptyTask, null!));
        ex.ParamName.ShouldBe("context");
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_function_should_throw_when_context_data_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAndCaptureAsync(_ => Task.FromResult(2), (IDictionary<string, object>)null!));
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_function_should_throw_when_context_is_null()
    {
        var policy = Policy
            .Handle<DivideByZeroException>()
            .RetryAsync((_, _, _) => { });

        var ex = await Should.ThrowAsync<ArgumentNullException>(() => policy.ExecuteAndCaptureAsync(_ => Task.FromResult(2), null!));
        ex.ParamName.ShouldBe("context");
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_function_should_pass_context_to_executed_delegate()
    {
        string operationKey = "SomeKey";
        Context executionContext = new Context(operationKey);
        Context? capturedContext = null;

        var policy = Policy.NoOpAsync();

        await policy.ExecuteAndCaptureAsync(context => { capturedContext = context; return TaskHelper.EmptyTask; }, executionContext);

        capturedContext.ShouldBeSameAs(executionContext);
    }

    [Fact]
    public async Task Execute_and_capturing_the_policy_function_should_pass_context_to_PolicyResult()
    {
        string operationKey = "SomeKey";
        Context executionContext = new Context(operationKey);

        var policy = Policy.NoOpAsync();

        (await policy.ExecuteAndCaptureAsync(_ => TaskHelper.EmptyTask, executionContext))
            .Context.ShouldBeSameAs(executionContext);
    }

    #endregion
}
