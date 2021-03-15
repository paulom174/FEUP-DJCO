using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControl : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint_t;
    public GameObject bulletPrefab;

    float timeUntilFire;
    Movement pm;
    Player p;

    private void Start()
    {
        pm = gameObject.GetComponent<Movement>();
        p = gameObject.GetComponent<Player>();

    }
 
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.X))) && timeUntilFire < Time.time && p.canShoot())
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint_t.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        p.ammoShot();
    }
}
