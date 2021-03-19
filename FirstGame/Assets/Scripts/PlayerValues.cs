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
    public TextMeshProUGUI value_time;
    Player p;

    private void Start()
    {
        p = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){

        //update bars
        value_health.localScale = new Vector3(p.health/100f, value_health.localScale.y, value_health.localScale.z);
        value_ammo.localScale = new Vector3(p.ammo/100f, value_ammo.localScale.y, value_ammo.localScale.z);

        // update text
        value_masks.text = "x" + p.masks + "/10";

    }
}
