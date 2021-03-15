using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Player player;

    void Start() {
        player = gameObject.GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Potion") {
            player.pickUpPotion();
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.tag == "Heart") {
            player.pickUpHeart();
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.tag == "Mask") {
            player.pickUpMask();
            Destroy(collider.gameObject);
        }
    }
}
