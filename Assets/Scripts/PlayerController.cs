using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Rigidbody2D rb;
    public float moveSpeed = 10;
    public float jumpForce;

    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;


    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;


    public float rememberGroundedFor; 
    float lastTimeGrounded;


    public Sprite spriteBaby;

    public Sprite spriteAdult;

    SpriteRenderer spriteRenderer;

    bool isBaby = false;
    
    BoxCollider2D collider;


    public float decisionMake;
    float lastdecision;


    Vector2 applyMotion;
    void ToBaby(){
        collider.offset = new Vector2(0, -.055f);
        collider.size = new Vector2(.07f, .05f);
        spriteRenderer.sprite = spriteBaby;
        isBaby = true;
    }

    void ToAdult(){
        collider.offset = new Vector2(0, 0);
        collider.size = new Vector2(.07f, .16f);
        spriteRenderer.sprite = spriteAdult;
        isBaby = false;
    }
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ToAdult();
    }

    bool IsGrounded(){
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 

        if(collider != null)
        lastTimeGrounded = Time.time;

        return collider != null;
    }

    void Jump() { 
        if (Input.GetAxis("Jump") > 0) { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        } 
    }


    void UserControl(){
        applyMotion = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0);
        rb.AddForce(applyMotion);
        if(IsGrounded() || (Time.time - lastTimeGrounded <= rememberGroundedFor)){
         
        Jump();
        }


        if(Input.GetAxis("Fire1") > 0){

            ToBaby();
        }

    }


    void RandomControl(){
        if(Time.time - lastdecision >= decisionMake ){
        applyMotion = new Vector2(Random.Range(-1.0f, 1.0f) * moveSpeed, 0);
        lastdecision = Time.time;
        }


        rb.AddForce(applyMotion);
    }
    void Update()
    {

        if(isBaby)
        RandomControl();
        else
        UserControl();

    if (rb.velocity.y < 0) {
        rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    } else if (rb.velocity.y > 0 && Input.GetAxis("Jump") <= 0) {
        rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }   


    }
}
