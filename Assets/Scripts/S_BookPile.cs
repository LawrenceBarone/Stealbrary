using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BookPile : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField] Rigidbody rb;
    [SerializeField] S_InputReader inputReader;

    [Header("Param")]
    [SerializeField] int maxPileUp = 10;
    [SerializeField] int currentAmount = 0;
    [SerializeField] float sensivity = 5;
    [SerializeField] float timeBeforeFall = 1;

    private void Awake()
    {
        inputReader.AttackEvent += OnGrab;
    }


    private void Update()
    {
        if (rb.velocity.magnitude >sensivity)
        {
            Debug.Log("reset");
            //currentAmount = 0;
            timeBeforeFall -= Time.deltaTime;

            if (timeBeforeFall<0)
            {

            }

        }
        else 
        {
            timeBeforeFall = 1;
        }
    }

    void OnGrab()
    {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one, Vector3.up, Quaternion.identity, Mathf.Infinity);

        foreach (var hit in hits)
        {
            if (hit.transform.CompareTag("BooksPile"))
            {
                currentAmount++;
                if (currentAmount > maxPileUp) currentAmount = maxPileUp;
                print("Win");
            }
        }
    }
}
