using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    Movement pm;
    Player p;

    private void Start()
    {
        pm = gameObject.GetComponent<Movement>();
        p = gameObject.GetComponent<Player>();
    }
 
    void Update()
    {
        //Update Animator parameters
        if(Mathf.Abs(pm.move) > 0.05){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }
        anim.SetBool("isGrounded", pm.ground);
        anim.SetBool("isDead", p.isDead);
    }
}
