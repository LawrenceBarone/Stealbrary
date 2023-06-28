using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Newtonsoft.Json;
using UnityEngine.UI;
using Unity.Services.Leaderboards.Models;
using Unity.Services.Leaderboards.Exceptions;

public class S_Leaderboard : MonoBehaviour
{

    [SerializeField] string leaderboardId;
    [SerializeField] TMPro.TMP_InputField nameInputField;
    [SerializeField] TMPro.TMP_Dropdown rankDropDown;
    [SerializeField] TMPro.TextMeshProUGUI WinTextLabel;



    public static string playerName;


    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            //if (AuthenticationService.Instance.IsSignedIn)
            //{
            //    nameInputField.text = AuthenticationService.Instance.GetPlayerNameAsync().Result;
            //}
        }
        catch (System.Exception ex)
        {
            Debug.Log("Offline");
        }

 

        //List<Dropdown.OptionData> optionDatas = new List<Dropdown.OptionData>();
        //Dropdown.OptionData optionData = new Dropdown.OptionData();
        //optionData.text = "Bronze";
        //optionDatas.Add(optionData);
        //rankDropDown.AddOptions("Bronze");
    }

    public void SetPlayerName(string _playerName)
    {
        if (_playerName != "")
        {
            playerName = _playerName;
            AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
        }
    }


    public async void AddScore(int score)
    {
        var playerEntry = await LeaderboardsService.Instance
            .AddPlayerScoreAsync(leaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }

    public async void GetScore()
    {
        WinTextLabel.text = "";

        try
        {
            var scores = await LeaderboardsService.Instance.GetScoresByTierAsync(leaderboardId, rankDropDown.options[rankDropDown.value].text.ToString());

            foreach (var result in scores.Results)
            {
                WinTextLabel.text += result.Rank.ToString() + " " + result.PlayerName + "\t" + result.Score;
            }
        }
        catch (LeaderboardsException ex)
        {
            print(rankDropDown.options[rankDropDown.value].text.ToString());
        }
    

    }
}
