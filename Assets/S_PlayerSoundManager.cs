using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerSoundManager : MonoBehaviour
{
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    public AudioSource audioSource;
    private RaycastHit hit;

    [SerializeField] Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    float initTime = 0.5f;
    float curTime = 0.5f;

    private void Update()
    {
        if (rb.velocity.magnitude > 2)
        {
            curTime -= Time.deltaTime;
            if (curTime<0)
            {
                curTime = initTime;
                PlaySound();
            }
        }
    }


    void PlaySound()
    {

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }

    //private AudioClip GetRandomFloorSound()
    //{
    //    if (hit.collider.CompareTag("WoodenFloor"))
    //    {
    //        return floorSounds[0]; // Change this to the appropriate sound for wooden floor
    //    }
    //    else if (hit.collider.CompareTag("ConcreteFloor"))
    //    {
    //        return floorSounds[1]; // Change this to the appropriate sound for concrete floor
    //    }
    //    else if (hit.collider.CompareTag("CarpetFloor"))
    //    {
    //        return floorSounds[2]; // Change this to the appropriate sound for carpet floor
    //    }
    //    else
    //    {
    //        // Default sound if no matching floor tag is found
    //        return floorSounds[3];
    //    }
    //}
}