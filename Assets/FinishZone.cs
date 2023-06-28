using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public int score = 0;
    [SerializeField] GameObject confetti;
    [SerializeField] AudioSource source;
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
}
