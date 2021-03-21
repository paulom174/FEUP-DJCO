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
    bool runningAway = false;
    public Transform doorExit;
    Player player;


    // Update is called once per frame
    void Update()
    {
        //origin, direction, distance, layerMask
        //shoot a raycast out from our groundCheck position, shoot it downwards for 1f unit, only checking if we are hiting ground
        //hitObstacles = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, obstacleLayers);
        hitObstacles = Physics2D.Raycast(inspector.position, transform.right, 1f, obstacleLayers);
        if(runningAway) {
            transform.position = Vector3.MoveTowards(transform.position, doorExit.position, Time.deltaTime * speed);
            // Debug.Log(Vector3.Lerp(runAwayStartPos, doorExit.position, Time.deltaTime));
        }
        
    }

    private void FixedUpdate()
    {
        if(!runningAway) {
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
    }

    public void runAway() {
        if(doorExit == null) {
            Debug.LogError("forgot to assign exit door");
        }
        if(isFacingRight) {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
        }

        runningAway = true;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
