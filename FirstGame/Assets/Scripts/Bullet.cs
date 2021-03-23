using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;

    public Rigidbody2D bullet_rb;
    Enemy enemy;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Bullet");
    }

    private void FixedUpdate()
    {
        bullet_rb.velocity = transform.right * bulletSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
       if (collison.gameObject.tag == "Enemy"){
           enemy = collison.gameObject.GetComponent<Enemy>();
           enemy.damageTaken();
       }
       if (collison.gameObject.tag == "Plataforms")
           return;
     
       // Debug.Log(collison.gameObject.tag);
       Destroy(gameObject);

    }

}
