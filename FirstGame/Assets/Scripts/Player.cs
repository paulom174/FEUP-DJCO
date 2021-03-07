using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        ammo = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }

        Debug.Log(ammo);
    }
}
