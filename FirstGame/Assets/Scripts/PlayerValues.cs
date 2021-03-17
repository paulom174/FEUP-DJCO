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
    public TextMeshProUGUI value_time;
    private float start_time;
    Player p;

    private void Start()
    {
        Time.timeScale = 0f;
        p = gameObject.GetComponent<Player>();
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update(){

        //scale bars
        value_health.localScale = new Vector3(p.health/100f, value_health.localScale.y, value_health.localScale.z);
        value_ammo.localScale = new Vector3(p.ammo/100f, value_ammo.localScale.y, value_ammo.localScale.z);

        // update values text
        value_masks.text = "x" + p.masks;
        value_score.text = "score: " + Mathf.Clamp( p.score, 0, 10000).ToString("0.00");
        if(!p.player_dead)
            value_time.text = Mathf.Clamp( Time.time - start_time, 0, 1000).ToString("0.00");

    }
}
