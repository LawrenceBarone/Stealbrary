using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public int score = 0;
    [SerializeField] GameObject confetti;
    [SerializeField] AudioSource source;

    private void Awake()
    {
        S_Gamemode.Instance.TimeUp += AddScore;
    }
    private void OnDisable()
    {
        S_Gamemode.Instance.TimeUp -= AddScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score = other.gameObject.GetComponent<S_BookPile>().GiveAllBooks();
            if (score != 0)
            {
                GameObject go = Instantiate(confetti, transform.position, Quaternion.identity);
                Destroy(go, 3);
                source.Play();
            }
        }
    }

    public async void AddScore()
    {
        try
        {
            if (AuthenticationService.Instance.IsAuthorized)
            {
                var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync("Score", score);
                Debug.Log(JsonConvert.SerializeObject(playerEntry));
            }
        }
        catch (System.Exception ex)
        {
            print("UploadFailed");
        }

    }
}
