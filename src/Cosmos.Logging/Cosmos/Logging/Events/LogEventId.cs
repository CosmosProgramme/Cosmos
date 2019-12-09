﻿using System;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event id
    /// </summary>
    public class LogEventId {
        private const int DefaultIntegerEventId = 0;

        /// <inheritdoc />
        public LogEventId() : this(string.Empty) { }

        /// <inheritdoc />
        public LogEventId(string name) : this(Guid.NewGuid().ToString(), name) { }

        /// <inheritdoc />
        public LogEventId(Guid id, string name) : this(id.ToString(), name) { }

        /// <inheritdoc />
        public LogEventId(int id, string name) : this(id.ToString(), name) { }

        /// <inheritdoc />
        public LogEventId(long id, string name) : this(id.ToString(), name) { }

        /// <inheritdoc />
        public LogEventId(string id, string name, string traceId = null) {
            var baseTime = DateTime.Now;
            Id = id;
            Timestamp = new DateTimeOffset(baseTime, TimeZoneInfo.Local.GetUtcOffset(baseTime));
            Name = name;
        }

        /// <summary>
        /// Gets timestamp
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Gets log event id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets trace id
        /// </summary>
        public string TraceId { get; }

        /// <summary>
        /// Gets log event name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Get integer event id
        /// </summary>
        /// <returns></returns>
        public int GetIntegerEventId() => int.TryParse(Id, out var ret) ? ret : DefaultIntegerEventId;
    }
}