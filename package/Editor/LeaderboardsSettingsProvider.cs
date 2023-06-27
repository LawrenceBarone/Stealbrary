using Unity.Services.Core.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.Services.Leaderboards.Settings
{
    public class LeaderboardsSettingsProvider : EditorGameServiceSettingsProvider
    {
        const string k_Title = "Leaderboards";
        const string k_GoToDashboardContainer = "dashboard-button-container";
        const string k_GoToDashboardBtn = "dashboard-link-button";
        
        static readonly LeaderboardsEditorGameService k_GameService = new LeaderboardsEditorGameService();
        
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new LeaderboardsSettingsProvider(SettingsScope.Project);
        }
        
        protected override IEditorGameService EditorGameService => k_GameService;
        protected override string Title => k_Title;
        protected override string Description => "Leaderboards allows you to store, sort, rank, and retrieve player scores quickly and easily within your game.";
        
        public LeaderboardsSettingsProvider(SettingsScope scopes)
            : base(GenerateProjectSettingsPath(k_Title), scopes) {}
        
        protected override VisualElement GenerateServiceDetailUI()
        {
            var containerVisualElement = new VisualElement();

            // No settings for Leaderboards at the moment

            return containerVisualElement;
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            SetDashboardButton(rootElement);
        }

        static void SetDashboardButton(VisualElement rootElement)
        {
            rootElement.Q(k_GoToDashboardContainer).style.display = DisplayStyle.Flex;
            var goToDashboard = rootElement.Q(k_GoToDashboardBtn);

            if (goToDashboard != null)
            {
                var clickable = new Clickable(() =>
                {
                    Application.OpenURL(k_GameService.GetFormattedDashboardUrl());
                });
                goToDashboard.AddManipulator(clickable);
            }
        }
    }
}