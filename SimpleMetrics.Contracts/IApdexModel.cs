namespace SimpleMetrics.Contracts
{
    public interface IApdexModel : IMetricsModel
    {
        double ApdexTSeconds { get; }
    }
}
