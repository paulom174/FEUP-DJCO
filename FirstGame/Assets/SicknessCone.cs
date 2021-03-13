using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicknessCone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            player.damageTaken();
        }
    }
}
