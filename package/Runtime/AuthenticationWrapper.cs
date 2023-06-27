using Unity.Services.Authentication.Internal;

namespace Unity.Services.Leaderboards
{
    interface IAuthentication
    {
        string GetAccessToken();
        string GetPlayerId();
    }

    class AuthenticationWrapper : IAuthentication
    {
        readonly IPlayerId m_PlayerId;
        readonly IAccessToken m_AccessToken;

        internal AuthenticationWrapper(IPlayerId playerId, IAccessToken accessToken)
        {
            m_PlayerId = playerId;
            m_AccessToken = accessToken;
        }

        public string GetAccessToken()
        {
            return m_AccessToken?.AccessToken;
        }

        public string GetPlayerId()
        {
            return m_PlayerId?.PlayerId;
        }
    }
}
