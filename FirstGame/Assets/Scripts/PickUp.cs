using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Player player;
    private AudioManager audio;

    void Start() {
        player = gameObject.GetComponent<Player>();
        audio = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Potion") {
            player.pickUpPotion();
            Destroy(collider.gameObject);
            audio.Play("Gain");
        }
        else if(collider.gameObject.tag == "Heart") {
            player.pickUpHeart();
            Destroy(collider.gameObject);
            audio.Play("Gain");
        }
        else if(collider.gameObject.tag == "Mask") {
            player.pickUpMask();
            Destroy(collider.gameObject);
            audio.Play("Gain");
        }
    }
}
