namespace SimpleMetrics.Contracts.Measuring
{
    public interface IIncrementMetricsCounters
    {
        void Increment(IMetricsModel model);
    }
}
