using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Device.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Leaderboards.Internal.Apis.Leaderboards;
using Unity.Services.Leaderboards.Exceptions;
using Unity.Services.Leaderboards.Internal;
using Unity.Services.Leaderboards.Internal.Http;
using UnityEngine;

namespace Unity.Services.Leaderboards
{
    class LeaderboardsInitializer : IInitializablePackage
    {
        const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment";
        const string k_StagingEnvironment = "staging";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Register()
        {
            CoreRegistry.Instance.RegisterPackage(new LeaderboardsInitializer())
                .DependsOn<ICloudProjectId>()
                .DependsOn<IPlayerId>()
                .DependsOn<IInstallationId>()
                .DependsOn<IProjectConfiguration>();
        }

        public Task Initialize(CoreRegistry registry)
        {
            var projectConfiguration = registry.GetServiceComponent<IProjectConfiguration>();
            var cloudProjectId = registry.GetServiceComponent<ICloudProjectId>();
            var accessToken = registry.GetServiceComponent<IAccessToken>();
            var playerId = registry.GetServiceComponent<IPlayerId>();

            IInternalLeaderboardsApiClient internalLeaderboardsApiClient = new InternalLeaderboardsApiClient(new HttpClient(), accessToken,
                new Configuration(GetHost(projectConfiguration), null, null, null));

            IAuthentication authentication = new AuthenticationWrapper(playerId, accessToken);

            ILeaderboardsApiClientInternal apiClient = new LeaderboardsApiClientInternal(cloudProjectId, authentication, internalLeaderboardsApiClient);

            LeaderboardsService.instance = new LeaderboardsServiceInternal(apiClient, new LeaderboardsApiErrorHandler(new RateLimiter()));

            return Task.CompletedTask;
        }

        string GetHost(IProjectConfiguration projectConfiguration)
        {
            var cloudEnvironment = projectConfiguration?.GetString(k_CloudEnvironmentKey);

            switch (cloudEnvironment)
            {
                case k_StagingEnvironment:
                    return "https://leaderboards-stg.services.api.unity.com";
                default:
                    return "https://leaderboards.services.api.unity.com";
            }
        }
    }
}
