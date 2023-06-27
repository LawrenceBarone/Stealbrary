using System;
using System.Collections.Generic;
using Unity.Services.Leaderboards.Internal.Models;
using UnityEngine.Scripting;

namespace Unity.Services.Leaderboards.Exceptions
{
    /// <summary>
    /// Represents a validation error from the Leaderboards service.
    /// <list>
    /// <listheader>
    /// <term>Properties</term>
    /// </listheader>
    /// <item>
    /// <term><see cref="P:System.Exception.Message">Message</see></term><description>Human readable message describing the error.</description>
    /// </item>
    /// <item>
    /// <term><see cref="P:Unity.Services.Leaderboards.Exceptions.LeaderboardsException.Reason">Reason</see></term><description>Service-specific reason why the error occurred.</description>
    /// </item>
    /// <item>
    /// <term><see cref="P:Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException.Details">Details</see></term><description>List of details outlining specific validation errors.</description>
    /// </item>
    /// </list>
    /// </summary>
    [Preserve]
    public class LeaderboardsValidationException : LeaderboardsException
    {
        [Preserve] public List<LeaderboardsValidationErrorDetail> Details { get; private set; }

        internal LeaderboardsValidationException(LeaderboardsExceptionReason reason, int errorCode, string message,
                                                 List<LeaderboardsValidationErrorDetail> details, Exception innerException)
            : base(reason, errorCode, AddDetailsToMessage(message, details), innerException)
        {
            Details = details;
        }

        static string AddDetailsToMessage(string message, IEnumerable<LeaderboardsValidationErrorDetail> details)
        {
            var detailsString = string.Join("; ", details);
            return $"{message} Invalid fields: {detailsString}";
        }
    }

    /// <summary>
    /// Single error in the Validation Error Response.
    /// <list>
    /// <listheader>
    /// <term>Properties</term>
    /// </listheader>
    /// <item><term>Field</term><description>The field in the data that caused the error.</description></item>
    /// <item><term>Messages</term><description>Messages that describe the errors in the given field.</description></item>
    /// </list>
    /// </summary>
    [Preserve]
    public class LeaderboardsValidationErrorDetail
    {
        /// <summary>
        /// Single error in the Validation Error Response.
        /// </summary>
        /// <param name="field">The field in the data that caused the error.</param>
        /// <param name="messages">Messages that describe the errors.</param>
        [Preserve]
        public LeaderboardsValidationErrorDetail(string field, List<string> messages)
        {
            Field = field;
            Messages = messages;
        }

        internal LeaderboardsValidationErrorDetail(ValidationError errorBody)
        {
            Field = errorBody.Field;
            Messages = errorBody.Messages;
        }

        [Preserve]
        public string Field { get; }

        [Preserve]
        public List<string> Messages { get; }

        [Preserve]
        public override string ToString()
        {
            return $"\"{Field}\" {string.Join(" and ", Messages)}";
        }
    }
}
