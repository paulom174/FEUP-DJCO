using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicknessCone : MonoBehaviour
{
    SpriteRenderer cone;
    Color tmp;

    public float minAlpha = 30f;
    public float maxAlpha = 150f;
    public float minRot = -8f;
    public float maxRot = 8f;
    public float speedAlpha = 100f;
    public float speedRot = 15f;
    void Start() {
        cone = gameObject.GetComponent<SpriteRenderer>();
        tmp = cone.color;
    }
    void Update() {
        tmp.a = (minAlpha + Mathf.PingPong(Time.time * speedAlpha, maxAlpha-minAlpha))/256;
        cone.color = tmp;
        Vector3 rot = transform.parent.localEulerAngles;
        rot.z = (minRot + Mathf.PingPong(Time.time * speedRot, maxRot-minRot));
        transform.parent.localEulerAngles = rot;
    }
    void OnTriggerStay2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            if(!gameObject.GetComponentInParent<Enemy>().HasMask())
                player.damageTaken();

            FindObjectOfType<AudioManager>().Play("Sneeze");
        }
    }
}
