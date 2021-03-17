using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int ammo;
    public int masks;
    public MenuCalls gameOverCanvas; 
    public float score;
    public bool player_dead;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        ammo = 100;
        masks = 10;
        score = 122;
        player_dead = false;
        gameObject.GetComponent<ShooterControl>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            //put death animation and disable movement from input 
            //

            gameOverCanvas.gameObject.SetActive(true);
            player_dead = true;
            gameObject.GetComponent<ShooterControl>().enabled = false;
        }
    }

    public void damageTaken() {
        health = health - 20f * Time.deltaTime;
        if(health < 0f)
            health = 0f;
    }
    public bool canShoot() {
        return ammo > 0;
    }
    public void ammoShot() {
        ammo = ammo - 10;
        if(ammo < 0)
            ammo = 0;
    }
    public bool canMask() {
        return masks > 0;
    }
    public void maskUp() {
        masks--;
        if(masks < 0)
            masks = 0;
    }
    public void pickUpPotion() {
        ammo = ammo + 10;
        if(ammo > 100)
            ammo = 100;
    }
    public void pickUpHeart() {
        health = health + 30;
        if(health > 100)
            health = 100;
    }
    public void pickUpMask() {
        masks++;
        if(masks > 10)
            masks = 10;
    }

}
