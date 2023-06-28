using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerState : MonoBehaviour
{

    bool stateContact = true;

    private void Start()
    {

    }
    public void PlayerIsChassed(bool _enemyContact)
    {
        stateContact = _enemyContact;
    }

    private void Update()
    {
        if (stateContact)
        {

        }
        
    }
}
