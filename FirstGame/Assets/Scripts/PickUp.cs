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
        if(collider.gameObject.tag == "Power Up") {
            player.ammo = player.ammo+ 10;
            Destroy(collider.gameObject);
        }
    }
}
