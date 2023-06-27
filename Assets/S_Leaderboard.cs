using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Newtonsoft.Json;
using UnityEngine.UI;

public class S_Leaderboard : MonoBehaviour
{

    [SerializeField] string leaderboardId;
    [SerializeField] Button NextPageBtn;
    [SerializeField] Button PreviousPageBtn;
    [SerializeField] Dropdown rankDropDown;


    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        //List<Dropdown.OptionData> optionDatas = new List<Dropdown.OptionData>();
        //Dropdown.OptionData optionData = new Dropdown.OptionData();
        //optionData.text = "Bronze";
        //optionDatas.Add(optionData);
        //rankDropDown.AddOptions("Bronze");
    }

    public async void AddScore(int score)
    {
        var playerEntry = await LeaderboardsService.Instance
            .AddPlayerScoreAsync(leaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }
}
