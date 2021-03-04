using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask obstacleLayers;
    public Transform inspector;
    RaycastHit2D hitObstacles;
    bool isFacingRight = true;


    // Update is called once per frame
    void Update()
    {
        //origin, direction, distance, layerMask
        //shoot a raycast out from our groundCheck position, shoot it downwards for 1f unit, only checking if we are hiting ground
        //hitObstacles = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, obstacleLayers);
        hitObstacles = Physics2D.Raycast(inspector.position, transform.right, 1f, obstacleLayers);
        
    }

    private void FixedUpdate()
    {
        if (hitObstacles.collider == false)//dont collide
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);//->
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);//<- 
            }

        }
        else//collide
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
       //if (collison.gameObject.CompareTag("Player")){
          
       //}
       //     gameObject.transform.localScale = new Vector3(transform.localScale.x*0.8f, transform.localScale.y*0.8f, 1f);
       // Destroy(gameObject);
    }
}
