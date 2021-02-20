using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Character Properties")]
    public float jumpForce = 20f;
    public int allowedJumps = 1;
    public float jumpResetTimer = 0.1f;
    public float acceleration = 30f;
    public float maxSpeed = 7f;
    public float maxSpeedWhileJump = 5f;
    [Range(0, 1)] public float drag = 0.9f;
    public LayerMask groundLayer;
    public float skinWidth = 0.01f;


    [Header("Runtime Variables")]
    [SerializeField] private bool jump = false;
    [SerializeField] private bool ground = false;
    [SerializeField] private float move;
    [SerializeField] private int jumpCounter;
    [SerializeField] private float jumpTimerCounter;
    private Rigidbody2D rb;
    private float rayLength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rayLength = transform.localScale.y * 0.5f + skinWidth;
        jumpCounter = allowedJumps;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        
        Color c = Color.red;

        if(hit.collider != null) {
            c = Color.blue;
            ground = true;
            if(jumpTimerCounter + jumpResetTimer < Time.time) {
                jumpCounter = allowedJumps;
            }
        }
        else {
            ground = false;
        }
        Debug.DrawRay(transform.position, Vector3.down * rayLength, c);

        if(Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0) {
            jump = true;
            jumpCounter--;
            jumpTimerCounter = Time.time;
        }

    }

    void FixedUpdate() {

        float velHorizontal = move * acceleration;
        rb.velocity += Vector2.right * velHorizontal * Time.fixedDeltaTime;
        Vector2 temp = rb.velocity;
        temp.x = Mathf.Clamp(temp.x, -maxSpeed, maxSpeed);

        if(move == 0) {
            temp.x *= drag;
        }

        if(ground == false) {
            temp.x = Mathf.Clamp(temp.x, -maxSpeedWhileJump, maxSpeedWhileJump);
        }

        if(jump) {
            temp.y = jumpForce;
            jump = false;
        }

        rb.velocity = temp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }
}
