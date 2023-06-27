using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Leaderboards.Exceptions;
using Unity.Services.Leaderboards.Internal.Http;
using Unity.Services.Leaderboards.Internal.Models;
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

namespace Unity.Services.Leaderboards.Internal
{
    class LeaderboardsServiceInternal : ILeaderboardsService
    {
        readonly ILeaderboardsApiClientInternal m_ApiClient;
        readonly ILeaderboardsApiErrorHandler m_ErrorHandler;

        public LeaderboardsServiceInternal(ILeaderboardsApiClientInternal apiClient, ILeaderboardsApiErrorHandler errorHandler)
        {
            m_ApiClient = apiClient;
            m_ErrorHandler = errorHandler;
        }

        public async Task<LeaderboardEntry> AddPlayerScoreAsync(string leaderboardId, double score)
        {
            LeaderboardEntry result = null;
            Response<Internal.Models.LeaderboardEntry> response;
            async Task AddPlayerScoreAsyncInternal()
            {
                response = await m_ApiClient.AddPlayerScoreAsync(leaderboardId, score);
                result = new LeaderboardEntry(response.Result);
            }

            await RunWithErrorHandling(AddPlayerScoreAsyncInternal);
            return result;
        }

        public async Task<LeaderboardScores> GetPlayerRangeAsync(string leaderboardId, GetPlayerRangeOptions options = null)
        {
            LeaderboardScores result = null;
            Response<Internal.Models.LeaderboardScores> response;
            async Task GetPlayerRangeInternal()
            {
                response = await m_ApiClient.GetPlayerRangeAsync(leaderboardId, options?.RangeLimit);
                result = new LeaderboardScores(response.Result);
            }

            await RunWithErrorHandling(GetPlayerRangeInternal);
            return result;
        }

        public async Task<LeaderboardEntry> GetPlayerScoreAsync(string leaderboardId)
        {
            LeaderboardEntry result = null;
            Response<Internal.Models.LeaderboardEntry> response;
            async Task GetPlayerScoreInternal()
            {
                response = await m_ApiClient.GetPlayerScoreAsync(leaderboardId);
                result = new LeaderboardEntry(response.Result);
            }

            await RunWithErrorHandling(GetPlayerScoreInternal);
            return result;
        }

        public async Task<LeaderboardScoresWithNotFoundPlayerIds> GetScoresByPlayerIdsAsync(string leaderboardId,
            List<string> playerIds)
        {
            LeaderboardScoresWithNotFoundPlayerIds result = null;
            Response<Internal.Models.LeaderboardScoresWithNotFoundPlayerIds> response;
            async Task GetScoresByPlayerIdsInternal()
            {
                response = await m_ApiClient.GetScoresByPlayerIdsAsync(leaderboardId, playerIds);
                result = new LeaderboardScoresWithNotFoundPlayerIds(response.Result);
            }

            await RunWithErrorHandling(GetScoresByPlayerIdsInternal);
            return result;
        }

        public async Task<LeaderboardScoresPage> GetScoresAsync(string leaderboardId, GetScoresOptions options = null)
        {
            LeaderboardScoresPage result = null;
            Response<Internal.Models.LeaderboardScoresPage> response;
            async Task GetScoresInternal()
            {
                response = await m_ApiClient.GetScoresAsync(leaderboardId, options?.Offset, options?.Limit);
                result = new LeaderboardScoresPage(response.Result);
            }

            await RunWithErrorHandling(GetScoresInternal);
            return result;
        }

        public async Task<LeaderboardTierScoresPage> GetScoresByTierAsync(string leaderboardId, string tierId, GetScoresByTierOptions options = null)
        {
            LeaderboardTierScoresPage result = null;
            Response<Internal.Models.LeaderboardTierScoresPage> response;
            async Task GetScoresByTierInternal()
            {
                response = await m_ApiClient.GetScoresByTierAsync(leaderboardId, tierId, options?.Offset, options?.Limit);
                result = new LeaderboardTierScoresPage(response.Result);
            }

            await RunWithErrorHandling(GetScoresByTierInternal);
            return result;
        }

        public async Task<LeaderboardVersionEntry> GetVersionPlayerScoreAsync(string leaderboardId, string versionId)
        {
            LeaderboardVersionEntry result = null;
            Response<Internal.Models.LeaderboardVersionEntry> response;
            async Task GetVersionPlayerScoreInternal()
            {
                response = await m_ApiClient.GetVersionPlayerScoreAsync(leaderboardId, versionId);
                result = new LeaderboardVersionEntry(response.Result);
            }

            await RunWithErrorHandling(GetVersionPlayerScoreInternal);
            return result;
        }

        public async Task<LeaderboardVersionScores> GetVersionPlayerRangeAsync(string leaderboardId,
            string versionId, GetVersionPlayerRangeOptions options = null)
        {
            LeaderboardVersionScores result = null;
            Response<Internal.Models.LeaderboardVersionScores> response;
            async Task GetVersionPlayerRangeInternal()
            {
                response = await m_ApiClient.GetVersionPlayerRangeAsync(leaderboardId, versionId, options?.RangeLimit);
                result = new LeaderboardVersionScores(response.Result);
            }

            await RunWithErrorHandling(GetVersionPlayerRangeInternal);
            return result;
        }

        public async Task<LeaderboardVersionScoresPage> GetVersionScoresAsync(string leaderboardId, string versionId, GetVersionScoresOptions options = null)
        {
            LeaderboardVersionScoresPage result = null;
            Response<Internal.Models.LeaderboardVersionScoresPage> response;
            async Task GetVersionScoresInternal()
            {
                response = await m_ApiClient.GetVersionScoresAsync(leaderboardId, versionId, options?.Offset, options?.Limit);
                result = new LeaderboardVersionScoresPage(response.Result);
            }

            await RunWithErrorHandling(GetVersionScoresInternal);
            return result;
        }

        public async Task<LeaderboardVersionScoresWithNotFoundPlayerIds> GetVersionScoresByPlayerIdsAsync(
            string leaderboardId, string versionId, List<string> playerIds)
        {
            LeaderboardVersionScoresWithNotFoundPlayerIds result = null;
            Response<Internal.Models.LeaderboardVersionScoresWithNotFoundPlayerIds> response;
            async Task GetVersionScoresByPlayerIdsInternal()
            {
                response = await m_ApiClient.GetVersionScoresByPlayerIdsAsync(leaderboardId, versionId, playerIds);
                result = new LeaderboardVersionScoresWithNotFoundPlayerIds(response.Result);
            }

            await RunWithErrorHandling(GetVersionScoresByPlayerIdsInternal);
            return result;
        }

        public async Task<LeaderboardVersionTierScoresPage> GetVersionScoresByTierAsync(string leaderboardId,
            string versionId, string tierId, GetVersionScoresByTierOptions options = null)
        {
            LeaderboardVersionTierScoresPage result = null;
            Response<Internal.Models.LeaderboardVersionTierScoresPage> response;
            async Task GetVersionScoresByTierInternal()
            {
                response = await m_ApiClient.GetVersionScoresByTierAsync(leaderboardId, versionId, tierId, options?.Offset, options?.Limit);
                result = new LeaderboardVersionTierScoresPage(response.Result);
            }

            await RunWithErrorHandling(GetVersionScoresByTierInternal);
            return result;
        }

        public async Task<LeaderboardVersions> GetVersionsAsync(string leaderboardId)
        {
            LeaderboardVersions result = null;
            Response<Internal.Models.LeaderboardVersions> response;
            async Task GetVersionsInternal()
            {
                response = await m_ApiClient.GetVersionsAsync(leaderboardId);
                result = new LeaderboardVersions(response.Result);
            }

            await RunWithErrorHandling(GetVersionsInternal);
            return result;
        }

        async Task RunWithErrorHandling(Func<Task> method)
        {
            try
            {
                if (m_ErrorHandler.IsRateLimited)
                {
                    throw m_ErrorHandler.CreateRateLimitException();
                }

                await method();
            }
            catch (HttpException<ValidationErrorResponse> e)
            {
                throw m_ErrorHandler.HandleValidationResponseException(e);
            }
            catch (HttpException<BasicErrorResponse> e)
            {
                throw m_ErrorHandler.HandleBasicResponseException(e);
            }
            catch (ResponseDeserializationException e)
            {
                throw m_ErrorHandler.HandleDeserializationException(e);
            }
            catch (HttpException e)
            {
                throw m_ErrorHandler.HandleHttpException(e);
            }
            catch (Exception e)
            {
                if (e is LeaderboardsException)
                {
                    throw;
                }

                throw m_ErrorHandler.HandleException(e);
            }
        }
    }
}
