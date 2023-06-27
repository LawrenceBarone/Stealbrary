using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float time = 60; 

    void Start()
    {
        time = startTime;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time<0)
        {
            Loose();
        }
    }

    public void Win()
    {

    }

    public void Loose()
    {

    }   
}
