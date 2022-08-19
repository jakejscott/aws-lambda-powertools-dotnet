using AWS.Lambda.Powertools.Metrics;

public class MetricsFunction
{
    public static async Task Main()
    {
        var function1 = new Function1();
        await function1.Handler();

        var function2 = new Function2();
        await function2.Handler();
    }
}

public class Function1
{
    [Metrics(Namespace = "TestNamespace1", Service = "TestService1")]
    public async Task Handler()
    {
        await Task.CompletedTask;
        Metrics.AddMetric("Metric1A", 1.0d, MetricUnit.Count);
    }
}

public class Function2
{
    [Metrics(Namespace = "TestNamespace2", Service = "TestService2")]
    public async Task Handler()
    {
        await Task.CompletedTask;
        Metrics.AddMetric("Metric1A", 1.0d, MetricUnit.Count);
    }
}