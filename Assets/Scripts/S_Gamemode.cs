using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Gamemode : MonoBehaviour
{
    

    private static S_Gamemode _instance;

    public static S_Gamemode Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            if (_instance != null)
            {
                return;
            }
            else
            {
                _instance = value;
            }
        }

    }

    void Awake()
    {
        _instance = this;
    }

    public float startTime = 60;
    public int score;
    public TMPro.TextMeshProUGUI display;
    float time = 60;
    bool GameOver = false;

    public Action TimeUp;

    [SerializeField] Transform player;
    [SerializeField] Transform startPosition;
    //Dictionary<string,score>() PlayerScore;

    void Start()
    {
        time = startTime;
    }

    void Update()
    {
        if (GameOver) return;

        time -= Time.deltaTime;
        display?.SetText("Time : " +time.ToString("F0"));

        if (time<0)
        {
            Loose();
        }
    }

    public void Loose()
    {
        GameOver = true;
        StartCoroutine(GameOverSequence());
        if (TimeUp != null) TimeUp();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("FancyShit");
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Game");
    }
}
