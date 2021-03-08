using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public bool coll;
    public PlatformEffector2D platform;
    private bool exit_plataform;

    public void Update() {
        if(coll && Input.GetKey(KeyCode.S)) {
            platform.surfaceArc = 0f;
            exit_plataform = false;
            //StartCoroutine(Wait());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // called when the player hits the plataform's collider
         if(collision.gameObject.CompareTag("Player") ){
            coll = true;
        }
 
    }
    private void OnCollisionExit2D(Collision2D collision) {
        // called when the player stops touching the plataform's collider
        if(collision.gameObject.CompareTag("Player") ){
            // if the player really exit the plataform reset surfaceArc
            // when surfaceArc was set to 0 the first exit collider will be a false exit
            if(exit_plataform)
                platform.surfaceArc = 125f;
            
            coll = false;
            exit_plataform = true;
        }
    }
    /*IEnumerator Wait() {
        yield return new WaitForSeconds(0.3f);
        platform.surfaceArc = 125f;
    }*/
    
}
