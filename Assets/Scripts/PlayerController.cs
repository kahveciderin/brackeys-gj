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


    public GameObject revEffect;

    Vector2 applyMotion;

    public float recordSpeed = 0.4f;
    float lastRecorded;

    public float playSpeed = 0.1f;

    bool stop;
    Stack<Vector2> playermovs = new Stack<Vector2>(); 
    Stack<Vector2> babymovs = new Stack<Vector2>(); 
    


    public int interpolaiton = 6;
    IEnumerator reverseBaby(){

        revEffect.SetActive(true);

        Vector2 previousPos = transform.position;
        for(int i = 0; i < playermovs.Count; i++) {
            
            Vector2 playbackthis = playermovs.Pop();
            Vector2 deltaPos = playbackthis - previousPos;


            for(int j = 1; j < interpolaiton + 1; j++){
                Vector2 addThis = j * (deltaPos / new Vector2(interpolaiton,interpolaiton));
                gameObject.transform.position = previousPos + addThis;
                
                yield return new WaitForSeconds(playSpeed);
            }
            babymovs.Push(playbackthis);
            previousPos = playbackthis;
        }


        collider.offset = new Vector2(0, -.055f);
        collider.size = new Vector2(.07f, .05f);
        spriteRenderer.sprite = spriteBaby;
        isBaby = true;

        for(int i = 0; i < babymovs.Count; i++) {
            Vector2 playbackthis = babymovs.Pop();
            Vector2 deltaPos = playbackthis - previousPos;

            for(int j = 1; j < interpolaiton + 1; j++){
            Vector2 addThis = j * (deltaPos / new Vector2(interpolaiton,interpolaiton));
            gameObject.transform.position =previousPos + addThis;
            yield return new WaitForSeconds(playSpeed);
            }

            previousPos = playbackthis;
        }


        stop = false;
        revEffect.SetActive(false);
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
        applyMotion = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);

        if(IsGrounded())
        rb.AddForce(applyMotion);
        if(IsGrounded() || (Time.time - lastTimeGrounded <= rememberGroundedFor)){
         
        Jump();
        }


        if(Input.GetAxis("Fire1") > 0){

            stop = true;
            StartCoroutine(reverseBaby());
        }


    if(Time.time - lastRecorded >= recordSpeed ){
        playermovs.Push(gameObject.transform.position);
        lastRecorded = Time.time;
    }
    }


    int rndmov(){
        float a = Random.Range(0f, 1f);

            //Debug.Log(a);
        return Mathf.Round(a) == 1 ? 1 : -1;
    }
    void RandomControl(){
        if(Time.time - lastdecision >= decisionMake ){
            int mov = rndmov();
        applyMotion = new Vector2( mov * moveSpeed, 0);
        lastdecision = Time.time;
        }


        rb.AddForce(applyMotion);
    }
    void Update()
    {
        if(!stop){
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
}
