using System.Collections.Generic;

namespace SimpleMetrics.Contracts
{
    /// <summary>
    /// {Namespace}_{ThingBeingMeasured}_{Unit}_{Suffix}
    /// </summary>
    public interface IMetricsModel
    {
        /// <summary>
        /// ...should have a (single-word) application prefix relevant to the domain the metric belongs to. The prefix is sometimes referred to as namespace by client libraries. For metrics specific to an application, the prefix is usually the application name itself. Sometimes, however, metrics are more generic, like standardized metrics exported by client libraries. Examples:
        /// prometheus_notifications_total (specific to the Prometheus server)
        /// process_cpu_seconds_total (exported by many client libraries)
        /// http_request_duration_seconds (for all HTTP requests)
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// ...should represent the same logical thing-being-measured across all label dimensions.
        /// request duration
        /// bytes of data transfer
        /// instantaneous resource usage as a percentage
        /// </summary>
        string ThingBeingMeasured { get; }

        /// <summary>
        /// ...must have a single unit (i.e. do not mix seconds with milliseconds, or seconds with bytes).
        /// ...should use base units (e.g. seconds, bytes, meters - not milliseconds, megabytes, kilometers). See below for a list of base units.
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// ...should have a suffix describing the unit, in plural form. Note that an accumulating count has total as a suffix, in addition to the unit if applicable.
        /// http_request_duration_seconds
        /// node_memory_usage_bytes
        /// http_requests_total (for a unit-less accumulating count)
        /// process_cpu_seconds_total (for an accumulating count with unit)
        /// </summary>
        string Suffix { get; }

        /// <summary>
        /// Use labels to differentiate the characteristics of the thing that is being measured:
        /// 
        /// api_http_requests_total - differentiate request types: type="create|update|delete"
        /// api_request_duration_seconds - differentiate request stages: stage="extract|transform|load"
        /// Do not put the label names in the metric name, as this introduces redundancy and will cause confusion if the respective labels are aggregated away.
        /// 
        /// CAUTION: Remember that every unique combination of key-value label pairs represents a new time series, which can dramatically increase the amount of data stored. Do not use labels to store dimensions with high cardinality (many different label values), such as user IDs, email addresses, or other unbounded sets of values.
        /// </summary>
        Dictionary<string, string> Tags { get; }
    }
}