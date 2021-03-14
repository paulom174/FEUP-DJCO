using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int ammo;
    public int masks;
    public menu game_over; 

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        ammo = 10;
        masks = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            //put death animation and disable movement from input instead of Destroy(gameObject);
            game_over.gameObject.SetActive(true);
        }

        Debug.Log(health);
    }

    public void damageTaken() {
        health = health - 20f * Time.deltaTime;
    }
}
