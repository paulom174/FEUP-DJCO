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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rayLength = transform.localScale.y * 3.2f + skinWidth;//Todo: change 0.6 to another value
        jumpCounter = allowedJumps;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

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
            temp.x *= dragWhileJump;
        }

        if(jump) {
            temp.y = jumpForce;
            jump = false;
        }

        rb.velocity = temp;
    }

    ContactPoint2D[] contacts = new ContactPoint2D[32];
    List <Vector2> debugPoints = new List<Vector2>();
    void OnCollisionStay2D(Collision2D col) 
    {
        int nContacts = col.GetContacts(contacts);
        //debugPoints.Clear();
        for (int i = 0; i < nContacts; i++) {
            //Points.Add(contacts[i].point);
            //Debug.Log(i);
            //Debug.Log(contacts[i].normal);
            if(contacts[i].normal == Vector2.up) {
                if(jumpTimerCounter + jumpResetTimer < Time.time) {
                    jumpCounter = allowedJumps;
                }
                ground = true;
                return;
            }
        }
        ground = false;
    }

    void OnDrawGizmos() {
        foreach (Vector2 item in debugPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(item, 0.5f);
        }
    }
}
