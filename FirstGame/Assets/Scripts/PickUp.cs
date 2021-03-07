using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Power Up") {
            Destroy(collider.gameObject);
        }
    }
}
