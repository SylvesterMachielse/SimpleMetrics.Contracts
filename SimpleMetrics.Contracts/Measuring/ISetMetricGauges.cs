namespace SimpleMetrics.Contracts.Measuring
{
    public interface ISetMetricsGauges
    {
        void Set(IMetricsModel model, int value);
        void Set(IMetricsModel model, double value);
    }
}
