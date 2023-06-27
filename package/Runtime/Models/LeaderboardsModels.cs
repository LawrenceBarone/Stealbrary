using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Leaderboards.Models
{
    /// <summary>
    /// LeaderboardEntry model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardEntry")]
    public class LeaderboardEntry
    {
        /// <summary>
        /// Creates an instance of LeaderboardEntry.
        /// </summary>
        /// <param name="playerId">playerId param</param>
        /// <param name="playerName">playerName param</param>
        /// <param name="rank">rank param</param>
        /// <param name="score">score param</param>
        /// <param name="tier">tier param</param>
        /// <param name="updatedTime">updatedTime param</param>
        [Preserve]
        public LeaderboardEntry(string playerId, string playerName, int rank, double score, string tier = default, DateTime updatedTime = default)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Rank = rank;
            Score = score;
            Tier = tier;
            UpdatedTime = updatedTime;
        }

        [Preserve]
        internal LeaderboardEntry(Internal.Models.LeaderboardEntry entry)
        {
            PlayerId = entry.PlayerId;
            PlayerName = entry.PlayerName;
            Rank = entry.Rank;
            Score = entry.Score;
            Tier = entry.Tier;
            UpdatedTime = entry.UpdatedTime;
        }

        /// <summary>
        /// Parameter playerId of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerId", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerId { get; }

        /// <summary>
        /// Parameter playerName of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerName", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerName { get; }

        /// <summary>
        /// Parameter rank of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "rank", IsRequired = true, EmitDefaultValue = true)]
        public int Rank { get; }

        /// <summary>
        /// Parameter score of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "score", IsRequired = true, EmitDefaultValue = true)]
        public double Score { get; }

        /// <summary>
        /// Parameter tier of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "tier", EmitDefaultValue = false)]
        public string Tier { get; }

        /// <summary>
        /// Parameter updatedTime of LeaderboardEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "updatedTime", EmitDefaultValue = false)]
        public DateTime UpdatedTime { get; }
    }

    /// <summary>
    /// LeaderboardScoresPage model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardScoresPage")]
    public class LeaderboardScoresPage
    {
        /// <summary>
        /// Creates an instance of LeaderboardScoresPage.
        /// </summary>
        /// <param name="offset">offset param</param>
        /// <param name="limit">limit param</param>
        /// <param name="total">total param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardScoresPage(int offset = default, int limit = default, int total = default, List<LeaderboardEntry> results = default)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        [Preserve]
        internal LeaderboardScoresPage(Internal.Models.LeaderboardScoresPage page)
        {
            Offset = page.Offset;
            Limit = page.Limit;
            Total = page.Total;
            Results = page.Results.ConvertAll(e => new LeaderboardEntry(e));
        }

        /// <summary>
        /// Parameter offset of LeaderboardScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; }

        /// <summary>
        /// Parameter limit of LeaderboardScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; }

        /// <summary>
        /// Parameter total of LeaderboardScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; }

        /// <summary>
        /// Parameter results of LeaderboardScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardScores model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardScores")]
    public class LeaderboardScores
    {
        /// <summary>
        /// Creates an instance of LeaderboardScores.
        /// </summary>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardScores(List<LeaderboardEntry> results = default)
        {
            Results = results;
        }

        [Preserve]
        internal LeaderboardScores(Internal.Models.LeaderboardScores scores)
        {
            Results = scores.Results.ConvertAll(e => new LeaderboardEntry(e));
        }

        /// <summary>
        /// Parameter results of LeaderboardScores
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardTierScoresPage model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardTierScoresPage")]
    public class LeaderboardTierScoresPage
    {
        /// <summary>
        /// Creates an instance of LeaderboardTierScoresPage.
        /// </summary>
        /// <param name="tier">tier param</param>
        /// <param name="offset">offset param</param>
        /// <param name="limit">limit param</param>
        /// <param name="total">total param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardTierScoresPage(string tier = default, int offset = default, int limit = default, int total = default, List<LeaderboardEntry> results = default)
        {
            Tier = tier;
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        [Preserve]
        internal LeaderboardTierScoresPage(Internal.Models.LeaderboardTierScoresPage page)
        {
            Tier = page.Tier;
            Offset = page.Offset;
            Limit = page.Limit;
            Total = page.Total;
            Results = page.Results.ConvertAll(e => new LeaderboardEntry(e));
        }

        /// <summary>
        /// Parameter tier of LeaderboardTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "tier", EmitDefaultValue = false)]
        public string Tier { get; }

        /// <summary>
        /// Parameter offset of LeaderboardTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; }

        /// <summary>
        /// Parameter limit of LeaderboardTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; }

        /// <summary>
        /// Parameter total of LeaderboardTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; }

        /// <summary>
        /// Parameter results of LeaderboardTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardScoresWithNotFoundPlayerIds model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardScoresWithNotFoundPlayerIds")]
    public class LeaderboardScoresWithNotFoundPlayerIds
    {
        /// <summary>
        /// Creates an instance of LeaderboardScoresWithNotFoundPlayerIds.
        /// </summary>
        /// <param name="results">results param</param>
        /// <param name="playerIds">entriesNotFoundForPlayerIds param</param>
        [Preserve]
        public LeaderboardScoresWithNotFoundPlayerIds(List<LeaderboardEntry> results = default, List<string> playerIds = default)
        {
            Results = results;
            EntriesNotFoundForPlayerIds = playerIds;
        }

        [Preserve]
        internal LeaderboardScoresWithNotFoundPlayerIds(Internal.Models.LeaderboardScoresWithNotFoundPlayerIds scores)
        {
            Results = scores.Results.ConvertAll(e => new LeaderboardEntry(e));
            EntriesNotFoundForPlayerIds = scores.EntriesNotFoundForPlayerIds;
        }

        /// <summary>
        /// Parameter results of LeaderboardScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }

        /// <summary>
        /// Parameter entriesNotFoundForPlayerIds of LeaderboardScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "entriesNotFoundForPlayerIds", EmitDefaultValue = false)]
        public List<string> EntriesNotFoundForPlayerIds { get; }
    }

    /// <summary>
    /// LeaderboardVersionScores model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionScores")]
    public class LeaderboardVersionScores
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionScores.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardVersionScores(LeaderboardVersion version = default, List<LeaderboardEntry> results = default)
        {
            Version = version;
            Results = results;
        }

        [Preserve]
        internal LeaderboardVersionScores(Internal.Models.LeaderboardVersionScores scores)
        {
            Results = scores.Results.ConvertAll(e => new LeaderboardEntry(e));
            Version = new LeaderboardVersion(scores.Version);
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionScores
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version { get; }

        /// <summary>
        /// Parameter results of LeaderboardVersionScores
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardVersionScoresWithNotFoundPlayerIds model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionScoresWithNotFoundPlayerIds")]
    public class LeaderboardVersionScoresWithNotFoundPlayerIds
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionScoresWithNotFoundPlayerIds.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="results">results param</param>
        /// <param name="playerIds">entriesNotFoundForPlayerIds param</param>
        [Preserve]
        public LeaderboardVersionScoresWithNotFoundPlayerIds(LeaderboardVersion version = default, List<LeaderboardEntry> results = default, List<string> playerIds = default)
        {
            Version = version;
            Results = results;
            EntriesNotFoundForPlayerIds = playerIds;
        }

        [Preserve]
        internal LeaderboardVersionScoresWithNotFoundPlayerIds(Internal.Models.LeaderboardVersionScoresWithNotFoundPlayerIds scores)
        {
            Results = scores.Results.ConvertAll(e => new LeaderboardEntry(e));
            EntriesNotFoundForPlayerIds = scores.EntriesNotFoundForPlayerIds;
            Version = new LeaderboardVersion(scores.Version);
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version { get; }

        /// <summary>
        /// Parameter results of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }

        /// <summary>
        /// Parameter entriesNotFoundForPlayerIds of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "entriesNotFoundForPlayerIds", EmitDefaultValue = false)]
        public List<string> EntriesNotFoundForPlayerIds { get; }
    }

    /// <summary>
    /// LeaderboardVersionEntry model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionEntry")]
    public class LeaderboardVersionEntry
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionEntry.
        /// </summary>
        /// <param name="playerId">playerId param</param>
        /// <param name="playerName">playerName param</param>
        /// <param name="rank">rank param</param>
        /// <param name="score">score param</param>
        /// <param name="version">version param</param>
        [Preserve]
        public LeaderboardVersionEntry(string playerId, string playerName, int rank, double score, LeaderboardVersion version = default)
        {
            Version = version;
            PlayerId = playerId;
            PlayerName = playerName;
            Rank = rank;
            Score = score;
        }

        [Preserve]
        internal LeaderboardVersionEntry(Internal.Models.LeaderboardVersionEntry entry)
        {
            PlayerId = entry.PlayerId;
            PlayerName = entry.PlayerName;
            Rank = entry.Rank;
            Score = entry.Score;
            Version = new LeaderboardVersion(entry.Version);
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version { get; }

        /// <summary>
        /// Parameter playerId of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerId", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerId { get; }

        /// <summary>
        /// Parameter playerName of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerName", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerName { get; }

        /// <summary>
        /// Parameter rank of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "rank", IsRequired = true, EmitDefaultValue = true)]
        public int Rank { get; }

        /// <summary>
        /// Parameter score of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "score", IsRequired = true, EmitDefaultValue = true)]
        public double Score { get; }
    }

    /// <summary>
    /// LeaderboardVersion model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersion")]
    public class LeaderboardVersion
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersion.
        /// </summary>
        /// <param name="id">id param</param>
        /// <param name="start">start param</param>
        /// <param name="end">end param</param>
        [Preserve]
        public LeaderboardVersion(string id = default, DateTime start = default, DateTime end = default)
        {
            Id = id;
            Start = start;
            End = end;
        }

        [Preserve]
        internal LeaderboardVersion(Internal.Models.LeaderboardVersion version)
        {
            Id = version.Id;
            Start = version.Start;
            End = version.End;
        }

        /// <summary>
        /// Parameter id of LeaderboardVersion
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        /// Parameter start of LeaderboardVersion
        /// </summary>
        [Preserve]
        [DataMember(Name = "start", EmitDefaultValue = false)]
        public DateTime Start { get; }

        /// <summary>
        /// Parameter end of LeaderboardVersion
        /// </summary>
        [Preserve]
        [DataMember(Name = "end", EmitDefaultValue = false)]
        public DateTime End { get; }
    }

    /// <summary>
    /// LeaderboardVersionScoresPage model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionScoresPage")]
    public class LeaderboardVersionScoresPage
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionScoresPage.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="offset">offset param</param>
        /// <param name="limit">limit param</param>
        /// <param name="total">total param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardVersionScoresPage(LeaderboardVersion version = default, int offset = default, int limit = default, int total = default, List<LeaderboardEntry> results = default)
        {
            Version = version;
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        [Preserve]
        internal LeaderboardVersionScoresPage(Internal.Models.LeaderboardVersionScoresPage page)
        {
            Version = new LeaderboardVersion(page.Version);
            Offset = page.Offset;
            Limit = page.Limit;
            Total = page.Total;
            Results = page.Results.ConvertAll(e => new LeaderboardEntry(e));
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version { get; }

        /// <summary>
        /// Parameter offset of LeaderboardVersionScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; }

        /// <summary>
        /// Parameter limit of LeaderboardVersionScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; }

        /// <summary>
        /// Parameter total of LeaderboardVersionScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; }

        /// <summary>
        /// Parameter results of LeaderboardVersionScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardVersionTierScoresPage model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionTierScoresPage")]
    public class LeaderboardVersionTierScoresPage
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionTierScoresPage.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="tier">tier param</param>
        /// <param name="offset">offset param</param>
        /// <param name="limit">limit param</param>
        /// <param name="total">total param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardVersionTierScoresPage(LeaderboardVersion version = default, string tier = default, int offset = default, int limit = default, int total = default, List<LeaderboardEntry> results = default)
        {
            Version = version;
            Tier = tier;
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        [Preserve]
        internal LeaderboardVersionTierScoresPage(Internal.Models.LeaderboardVersionTierScoresPage page)
        {
            Version = new LeaderboardVersion(page.Version);
            Tier = page.Tier;
            Offset = page.Offset;
            Limit = page.Limit;
            Total = page.Total;
            Results = page.Results.ConvertAll(e => new LeaderboardEntry(e));
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version { get; }

        /// <summary>
        /// Parameter tier of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "tier", EmitDefaultValue = false)]
        public string Tier { get; }

        /// <summary>
        /// Parameter offset of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset { get; }

        /// <summary>
        /// Parameter limit of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; }

        /// <summary>
        /// Parameter total of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; }

        /// <summary>
        /// Parameter results of LeaderboardVersionTierScoresPage
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results { get; }
    }

    /// <summary>
    /// LeaderboardVersions model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersions")]
    public class LeaderboardVersions
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersions.
        /// </summary>
        /// <param name="leaderboardId">leaderboardId param</param>
        /// <param name="results">results param</param>
        /// <param name="nextReset">nextReset param</param>
        [Preserve]
        public LeaderboardVersions(string leaderboardId = default, List<LeaderboardVersion> results = default, DateTime nextReset = default)
        {
            LeaderboardId = leaderboardId;
            Results = results;
            NextReset = nextReset;
        }

        [Preserve]
        internal LeaderboardVersions(Internal.Models.LeaderboardVersions versions)
        {
            LeaderboardId = versions.LeaderboardId;
            Results = versions.Results.ConvertAll(v => new LeaderboardVersion(v));
            NextReset = versions.NextReset;
        }

        /// <summary>
        /// Parameter leaderboardId of LeaderboardVersions
        /// </summary>
        [Preserve]
        [DataMember(Name = "leaderboardId", EmitDefaultValue = false)]
        public string LeaderboardId { get; }

        /// <summary>
        /// Parameter results of LeaderboardVersions
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardVersion> Results { get; }

        /// <summary>
        /// Parameter nextReset of LeaderboardVersions
        /// </summary>
        [Preserve]
        [DataMember(Name = "nextReset", EmitDefaultValue = false)]
        public DateTime NextReset { get; }
    }
}
