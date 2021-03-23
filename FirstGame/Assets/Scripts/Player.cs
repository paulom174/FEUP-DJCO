using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public int ammo;
    public int masks;
    public float score;
    public bool isDead;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        ammo = 100;
        masks = 1;
        score = 0;
        gameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && !isDead) {
            gameState.PlayerDied();
        }
    }

    public void damageTaken() {
        health = health - 20f * Time.deltaTime * 2;
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
        gameState.addScore(20);
    }
    public void pickUpPotion() {
        ammo = ammo + 50;
        if(ammo > 100)
            ammo = 100;
    }
    public void pickUpHeart() {
        health = 100;
    }
    public void pickUpMask() {
        masks = masks + 4;
        if(masks > 10)
            masks = 10;
    }

}
