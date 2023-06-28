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

    //Dictionary<string,score>() PlayerScore;

    void Start()
    {
        time = startTime;
    }

    void Update()
    {
        if (GameOver) return;

        time -= Time.deltaTime;
        display?.SetText(time.ToString("F0"));

        if (time<0)
        {
            Loose();
        }
    }

    public void Loose()
    {
        GameOver = true;
        StartCoroutine(GameOverSequence());
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Game");
    }
}
