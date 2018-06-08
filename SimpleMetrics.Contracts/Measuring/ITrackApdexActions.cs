using System;

namespace SimpleMetrics.Contracts.Measuring
{
    public interface ITrackApdexActions
    {
        IDisposable Track(IApdexModel model);
    }
}
