using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector] public bool isFacingRight = true;

    [Header("Character Properties")]
    public float jumpForce = 20f;
    public int allowedJumps = 1;
    public float jumpResetTimer = 0.1f;
    public float acceleration = 50f;
    public float maxSpeed = 15f;
    [Range(0, 1)] public float drag = 0.99f;
    [Range(0, 1)] public float dragWhileJump = 0.9f;
    public LayerMask groundLayer;
    public float skinWidth = 0.01f;


    [Header("Runtime Variables")]
    [SerializeField] private bool jump = false;
    public bool ground = false;
    //[SerializeField] private bool ground = false;
    public float move;
    //[SerializeField] private float move;
    [SerializeField] private int jumpCounter;
    [SerializeField] private float jumpTimerCounter;
    private Rigidbody2D rb;
    private float rayLength;

    RaycastHit2D playerHit;

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

        RaycastHit2D centralHit = Physics2D.Raycast(transform.position - new Vector3(0, 1.4f, 0), Vector2.down, rayLength, groundLayer);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position - new Vector3(0.6f, 1.4f, 0), Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + new Vector3(0.6f, -1.4f, 0), Vector2.down, rayLength, groundLayer);

        Color c = Color.red;

        if(centralHit.collider != null || leftHit.collider != null || rightHit.collider != null) {
            c = Color.blue;
            ground = true;
            if(jumpTimerCounter + jumpResetTimer < Time.time) {
                jumpCounter = allowedJumps;
            }
        }
        else {
            ground = false;
        }

        Debug.DrawRay(transform.position - new Vector3(0, 1.4f, 0), Vector3.down * rayLength, c);
        Debug.DrawRay(transform.position - new Vector3(0.5f, 1.4f, 0), Vector3.down * rayLength, c);
        Debug.DrawRay(transform.position + new Vector3(0.5f, -1.4f, 0), Vector3.down * rayLength, c);

        if((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow))) && jumpCounter > 0) {
            jump = true;
            jumpCounter--;
            jumpTimerCounter = Time.time;
        }

        if (move < 0) {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
            isFacingRight = false;
        }
        else if (move > 0) {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            isFacingRight = true;
        }

        if(isFacingRight) {
            playerHit = Physics2D.Raycast(transform.position, Vector2.right, 1.4f, groundLayer);
            Debug.DrawRay(transform.position, Vector3.right * 1.4f, c);
            
        }
        else {
            playerHit = Physics2D.Raycast(transform.position, Vector2.left, 1.4f, groundLayer);
            Debug.DrawRay(transform.position, Vector3.left * 1.4f, c);
        }

        if(playerHit.collider.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.C)) {
            Enemy enemy = playerHit.collider.gameObject.GetComponent<Enemy>();
            enemy.placeMask();
        }


    }

    void FixedUpdate() {

        float velHorizontal = move * acceleration;
        rb.velocity += Vector2.right * velHorizontal * Time.fixedDeltaTime * 1.5f;
        Vector2 temp = rb.velocity;
        temp.x = Mathf.Clamp(temp.x, -maxSpeed, maxSpeed);

        if(move == 0) {
            temp.x *= drag;
        }

        if(ground == false) {
            temp.x *= dragWhileJump;
        }

        if(jump) {
            temp.y = jumpForce;
            jump = false;
        }

        rb.velocity = temp;
    }
}
