using Unity.Services.Core.Editor;
using Unity.Services.Core.Editor.OrganizationHandler;
using UnityEditor;

namespace Unity.Services.Leaderboards.Settings
{
    struct LeaderboardsIdentifier : IEditorGameServiceIdentifier
    {
        public string GetKey() => "Leaderboards";
    }
    public class LeaderboardsEditorGameService : IEditorGameService
    {
        public string Name => "Leaderboards";
        public IEditorGameServiceIdentifier Identifier => k_Identifier;
        public bool RequiresCoppaCompliance => false;
        public bool HasDashboard => true;
        public IEditorGameServiceEnabler Enabler => null;

        static readonly LeaderboardsIdentifier k_Identifier = new LeaderboardsIdentifier();

        public string GetFormattedDashboardUrl()
        {
            return
                $"https://dashboard.unity3d.com/organizations/{OrganizationProvider.Organization.Key}/projects/{CloudProjectSettings.projectId}/leaderboards/about";
        }
    }
}