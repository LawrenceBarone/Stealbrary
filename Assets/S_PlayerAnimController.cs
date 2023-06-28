using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerAnimController : MonoBehaviour
{
    [SerializeField] S_BookPile booksPile;
    [SerializeField] Animator anim;
    /*
    // Start is called before the first frame update
    void Awake()
    {
        booksPile.OnTakeBook += UpdateAnimation;
    }

    // Update is called once per frame
    void UpdateAnimation()
    {
        if (booksPile.currentAmount>0)
        {
            anim.SetBool("isHolding",true);
        }
        else
        {
            anim.SetBool("isHolding", false);
        }
    }
    */
}
