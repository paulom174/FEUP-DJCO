using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerValues : MonoBehaviour
{
    public Transform value_health;
    public Transform value_ammo;
    public TextMeshProUGUI value_masks;
    public TextMeshProUGUI value_score;
    Player p;

    private void Start()
    {
        p = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){

        //scale
        value_health.localScale = new Vector3(p.health/100f, value_health.localScale.y, value_health.localScale.z);
        value_ammo.localScale = new Vector3(p.ammo/100f, value_ammo.localScale.y, value_ammo.localScale.z);

        value_masks.text = "x" + p.masks;
        value_score.text = "score: " + p.score;

        /*Debug.Log("Health " + p.health  + " % " + value_health.localScale.x
        + "  |Ammo " + p.ammo + " % " + value_ammo.localScale.x
        + "  |Masks " + p.masks + " % " + value_masks.text);*/

    }
}
