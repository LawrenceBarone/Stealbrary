using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using LeaderboardEntry = Unity.Services.Leaderboards.Models.LeaderboardEntry;
using LeaderboardScoresPage = Unity.Services.Leaderboards.Models.LeaderboardScoresPage;
using LeaderboardScores = Unity.Services.Leaderboards.Models.LeaderboardScores;
using LeaderboardVersionEntry = Unity.Services.Leaderboards.Models.LeaderboardVersionEntry;
using LeaderboardVersions = Unity.Services.Leaderboards.Models.LeaderboardVersions;
using LeaderboardVersionScores = Unity.Services.Leaderboards.Models.LeaderboardVersionScores;
using LeaderboardVersionScoresPage = Unity.Services.Leaderboards.Models.LeaderboardVersionScoresPage;
using LeaderboardScoresWithNotFoundPlayerIds = Unity.Services.Leaderboards.Models.LeaderboardScoresWithNotFoundPlayerIds;
using LeaderboardVersionScoresWithNotFoundPlayerIds = Unity.Services.Leaderboards.Models.LeaderboardVersionScoresWithNotFoundPlayerIds;
using LeaderboardTierScoresPage = Unity.Services.Leaderboards.Models.LeaderboardTierScoresPage;
using LeaderboardVersionTierScoresPage = Unity.Services.Leaderboards.Models.LeaderboardVersionTierScoresPage;

namespace Unity.Services.Leaderboards
{
    /// <summary>
    /// The entry class to the Leaderboards service.
    /// </summary>
    public static class LeaderboardsService
    {
        internal static ILeaderboardsService instance;

        /// <summary>
        /// The default singleton instance to access the Leaderboards service.
        /// </summary>
        /// <exception cref="ServicesInitializationException">
        /// This exception is thrown if the <code>UnityServices.InitializeAsync()</code>
        /// has not finished before accessing the singleton.
        /// </exception>
        public static ILeaderboardsService Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new ServicesInitializationException("The Leaderboards service has not been initialized. Please initialize Unity Services.");
                }

                return instance;
            }
        }
    }

    public class RangeOptions
    {
        public int? RangeLimit { get; set; }
    }

    public class GetPlayerRangeOptions : RangeOptions {}
    public class GetVersionPlayerRangeOptions : RangeOptions {}

    public class PaginationOptions
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
    }

    public class GetScoresOptions : PaginationOptions {}
    public class GetScoresByTierOptions : PaginationOptions {}
    public class GetVersionScoresOptions : PaginationOptions {}
    public class GetVersionScoresByTierOptions : PaginationOptions {}

    public interface ILeaderboardsService
    {
        /// <summary>
        /// Adds or updates an entry for the current player in the specified leaderboard.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="score">Score value to be submitted</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardEntry object containing the added or updated entry.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardEntry> AddPlayerScoreAsync(string leaderboardId, double score);
        /// <summary>
        /// Gets the entries of the current player as well as the specified number of neighboring players ranked either side of the player.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="options">Options object with "RangeLimit", the number of entries either side of the player to retrieve. Defaults to 5.</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardScores object containing the list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardScores> GetPlayerRangeAsync(string leaderboardId, GetPlayerRangeOptions options = null);
        /// <summary>
        /// Gets the entry for the current player in the specified leaderboard.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardEntry object containing the retrieved entry.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardEntry> GetPlayerScoreAsync(string leaderboardId);
        /// <summary>
        /// Gets a paginated list of entries for the specified leaderboard.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="options">Options object with "Offset" and "Limit" pagination options.
        /// "Offset" is the number of entries to skip when retrieving the leaderboard scores, defaults to 0.
        /// "Limit" is the number of leaderboard scores to return, defaults to 10.
        /// </param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardScoresPage object containing the paginated list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardScoresPage> GetScoresAsync(string leaderboardId, GetScoresOptions options = null);
        /// <summary>
        /// Gets a paginated list of entries for the specified leaderboard within the specified tier.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="tierId">ID string of the tier</param>
        /// <param name="options">Options object with "Offset" and "Limit" pagination options.
        /// "Offset" is the number of entries to skip when retrieving the leaderboard scores, defaults to 0.
        /// "Limit" is the number of leaderboard scores to return, defaults to 10.
        /// </param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardTierScoresPage object containing the paginated list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardTierScoresPage> GetScoresByTierAsync(string leaderboardId, string tierId,
            GetScoresByTierOptions options = null);
        /// <summary>
        /// Gets the entry for the current player in the specified leaderboard archive version.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="versionId">ID string of the leaderboard archive version</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersionEntry object containing the retrieved entry.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersionEntry> GetVersionPlayerScoreAsync(string leaderboardId,
            string versionId);
        /// <summary>
        /// Gets the entries of the current player as well as the specified number of neighboring players ranked
        /// either side of the player in the specified leaderboard archive version.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="versionId">ID string of the leaderboard archive version</param>
        /// <param name="options">Options object with "RangeLimit", the number of entries either side of the player to retrieve. Defaults to 5.</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersionScores object containing the list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersionScores> GetVersionPlayerRangeAsync(string leaderboardId, string versionId,
            GetVersionPlayerRangeOptions options = null);
        /// <summary>
        /// Gets a list of entries from the specified leaderboard for the specified player IDs.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="playerIds">List of player IDs to get entries for</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardScores object containing the list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardScoresWithNotFoundPlayerIds> GetScoresByPlayerIdsAsync(string leaderboardId,
            List<string> playerIds);
        /// <summary>
        /// Gets a paginated list of entries for the specified leaderboard archive version.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="versionId">ID string of the leaderboard archive version</param>
        /// <param name="options">Options object with "Offset" and "Limit" pagination options.
        /// "Offset" is the number of entries to skip when retrieving the leaderboard scores, defaults to 0.
        /// "Limit" is the number of leaderboard scores to return, defaults to 10.
        /// </param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersionScoresPage object containing the paginated list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersionScoresPage> GetVersionScoresAsync(string leaderboardId,
            string versionId, GetVersionScoresOptions options = null);
        /// <summary>
        /// Gets a list of entries for the specified players by player ID from the specified leaderboard archive version.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="versionId">ID string of the leaderboard archive version</param>
        /// <param name="playerIds">List of player IDs to get scores for</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersionScoresByPlayerIds object containing the list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersionScoresWithNotFoundPlayerIds> GetVersionScoresByPlayerIdsAsync(string leaderboardId,
            string versionId, List<string> playerIds);
        /// <summary>
        /// Gets a paginated list of entries from the specified leaderboard archive version and within the specified tier.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <param name="versionId">ID string of the leaderboard archive version</param>
        /// <param name="tierId">ID string of the tier</param>
        /// <param name="options">Options object with "Offset" and "Limit" pagination options.
        /// "Offset" is the number of entries to skip when retrieving the leaderboard scores, defaults to 0.
        /// "Limit" is the number of leaderboard scores to return, defaults to 10.
        /// </param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersionTierScoresPage object containing the paginated list of retrieved entries.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersionTierScoresPage> GetVersionScoresByTierAsync(string leaderboardId, string versionId,
            string tierId, GetVersionScoresByTierOptions options = null);
        /// <summary>
        /// Gets the list of archived leaderboard versions for the specified leaderboard.
        /// </summary>
        /// <param name="leaderboardId">ID string of the leaderboard</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.LeaderboardVersions object containing the list of retrieved versions.</returns>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsException">An exception containing a Message, Reason, and ErrorCode that can be used to determine the source of the error.</exception>
        /// <exception cref="Unity.Services.Leaderboards.Exceptions.LeaderboardsValidationException">An exception containing a Message, Reason, ErrorCode, and Details that can be used to determine the source of the error.</exception>
        Task<LeaderboardVersions> GetVersionsAsync(string leaderboardId);
    }
}
