using System;
using Unity.Services.Core;
using UnityEngine.Scripting;

namespace Unity.Services.Leaderboards.Exceptions
{
    /// <summary>
    /// An enum of possible reasons that Leaderboards would throw an exception.
    /// <list>
    /// <item><term>Unknown</term><description>An unknown error occurred.</description></item>
    /// <item><term>NoInternetConnection</term><description>No internet connection.</description></item>
    /// <item><term>ProjectIdMissing</term><description>Request did not include a Project Id.</description></item>
    /// <item><term>PlayerIdMissing</term><description>Request did not include a Player Id</description></item>
    /// <item><term>AccessTokenMissing</term><description>Access token is missing from the request.</description></item>
    /// <item><term>InvalidArgument</term><description>Generic reason indicating an argument in the request was invalid, commonly used in <see cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">LeaderboardValidationException</see>.</description></item>
    /// <item><term>LeaderboardNotBucketed</term><description>A request that can only be made on a bucketed leaderboard was made on a non-bucketed leaderboard.</description></item>
    /// <item><term>LeaderboardBucketed</term><description>A request that can only be made on a non-bucketed leaderboard was made on a bucketed leaderboard.</description></item>
    /// <item><term>LeaderboardNotTiered</term><description>A request that can only be made on a tiered leaderboard was made on a non-tiered leaderboard.</description></item>
    /// <item><term>Unauthorized</term><description>Player is not authorized to access this resource.</description></item>
    /// <item><term>LeaderboardNotFound</term><description>The leaderboard requested was not found.</description></item>
    /// <item><term>EntryNotFound</term><description></description>The leaderboard entry requested was not found.</item>
    /// <item><term>VersionNotFound</term><description>The leaderboard version requested was not found.</description></item>
    /// <item><term>BucketNotFound</term><description>The leaderboard bucket requested was not found.</description></item>
    /// <item><term>TierNotFound</term><description>The leaderboard tier requested was not found.</description></item>
    /// <item><term>NotFound</term><description>Generic reason indicating that one of the entities specified in the request was not found.</description></item>
    /// <item><term>TooManyRequests</term><description>Rate limit has been exceeded, please wait and try again.</description></item>
    /// <item><term>ServiceUnavailable</term><description>Generic reason indicating there was an error communicating with the service.</description></item>
    /// <item><term>ScoreSubmissionRequired</term><description>Request attempted to read from a bucketed leaderboard before the player submitted a score and was assigned a bucket.</description></item>
    /// </list>
    /// </summary>
    [Preserve]
    public enum LeaderboardsExceptionReason
    {
        Unknown = 0,
        NoInternetConnection,
        ProjectIdMissing,
        PlayerIdMissing,
        AccessTokenMissing,
        InvalidArgument,
        LeaderboardNotBucketed,
        LeaderboardBucketed,
        LeaderboardNotTiered,
        Unauthorized,
        LeaderboardNotFound,
        EntryNotFound,
        VersionNotFound,
        BucketNotFound,
        TierNotFound,
        NotFound,
        TooManyRequests,
        ServiceUnavailable,
        ScoreSubmissionRequired
    }

    /// <summary>
    /// Represents a generic error.
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
    /// </list>
    /// </summary>
    [Preserve]
    public class LeaderboardsException : RequestFailedException
    {
        /// <summary> Gets the Leaderboards service-specific reason why the error occurred.</summary>
        [Preserve] public LeaderboardsExceptionReason Reason { get; private set; }

        internal LeaderboardsException(LeaderboardsExceptionReason reason, int errorCode, string message, Exception innerException)
            : base(errorCode, message, innerException)
        {
            Reason = reason;
        }
    }
}
