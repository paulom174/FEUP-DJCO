using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public MenuCalls winCanvas; 

    void OnTriggerEnter2D(Collider2D collider) {

       if (collider.gameObject.tag == "Goal"){
            winCanvas.gameObject.SetActive(true);
            Destroy(gameObject);
            AudioManager audio = FindObjectOfType<AudioManager>();
            //audio.Stop("Ambient");
            audio.Play("GameWin");
       }

       
    }


}
