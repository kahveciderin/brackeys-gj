using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BetterController))]
public class BetterPlayerMovement : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    BetterController controller;

    public Sprite spriteBaby;

    public Sprite spriteAdult;
    SpriteRenderer spriteRenderer;

    bool isBaby = false;
    BoxCollider2D collider;
    public GameObject revEffect;

    public float recordSpeed = 0.4f;
    float lastRecorded;

    public float playSpeed = 0.1f;

    bool stop;
    Stack<Vector2> playermovs = new Stack<Vector2>();
    Stack<Vector2> babymovs = new Stack<Vector2>();

    private Animator animator;

    public int interpolaiton = 6;

    public bool isPaused = false;

    public GameObject babyDoggo;
    void Start()
    {
        controller = GetComponent<BetterController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        animator = GetComponent<Animator>();

        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playermovs.Push(gameObject.transform.position);
        lastRecorded = Time.time;
        ToAdult();


        //print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        if(!isPaused){
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            animator.SetBool("isFalling", false);
        }

        if (velocity.y < 0f)
        {
            animator.SetBool("isFalling", true);
        }

        if (!stop)
        {
            Vector2 input;
            if (isBaby)
            {
                input = new Vector2(1, 0);
            }
            else
            {

                input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                animator.SetBool("isRunning", (input.x != 0f) ? true : false);

                if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
                {
                    velocity.y = jumpVelocity;
                    animator.SetTrigger("Jumping");
                }


                if (Time.time - lastRecorded >= recordSpeed)
                {
                    playermovs.Push(gameObject.transform.position);
                    lastRecorded = Time.time;
                }


                if (Input.GetAxis("Fire1") > 0)
                {

                    stop = true;
                    playermovs.Push(gameObject.transform.position);
                    lastRecorded = Time.time;
                    playermovs.Push(gameObject.transform.position);
                    lastRecorded = Time.time;
                    StartCoroutine(reverseBaby());
                }

            }


            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);


        }


        if(velocity.x > 0){
            transform.localScale = new Vector2(5,5);
        }else if(velocity.x < 0){
            transform.localScale = new Vector2(-5,5);
        }

        }
    }


    IEnumerator reverseBaby()
    {


        revEffect.SetActive(true);

        Vector2 previousPos = transform.position;
        for (int i = 0; i < playermovs.Count; i++)
        {

            Vector2 playbackthis = playermovs.Pop();
            Vector2 deltaPos = playbackthis - previousPos;


            for (int j = 1; j < interpolaiton + 1; j++)
            {
                Vector2 addThis = j * (deltaPos / new Vector2(interpolaiton, interpolaiton));
                gameObject.transform.position = previousPos + addThis;

                yield return new WaitForSeconds(playSpeed);
            }
            babymovs.Push(playbackthis);
            previousPos = playbackthis;
        }

        GameObject.FindGameObjectsWithTag("Blocker")[0].SetActive(false);


        collider.offset = new Vector2(-0.03f, -.06f);
        collider.size = new Vector2(.18f, .12f);
        babyDoggo.SetActive(true);
        spriteRenderer.enabled = false;
        isBaby = true;

        for (int i = 0; i < babymovs.Count; i++)
        {
            Vector2 playbackthis = babymovs.Pop();
            Vector2 deltaPos = playbackthis - previousPos;

            for (int j = 1; j < interpolaiton + 1; j++)
            {
                Vector2 addThis = j * (deltaPos / new Vector2(interpolaiton, interpolaiton));
                //gameObject.transform.position = previousPos + addThis;
                yield return new WaitForSeconds(playSpeed);
            }

            previousPos = playbackthis;
        }


        stop = false;
        revEffect.SetActive(false);

        controller.CalculateRaySpacing();
    }

    public void ResetPlayer()
    {

        lastRecorded = Time.time;
        ToAdult();
        playermovs.Clear();
        transform.position = Vector3.zero;
    }
    void ToAdult()
    {
        babyDoggo.SetActive(false);
        spriteRenderer.enabled = true;
        collider.offset = new Vector2(0, -.03f);
        collider.size = new Vector2(.2f, .15f);
        //spriteRenderer.sprite = spriteAdult;
        isBaby = false;


        controller.CalculateRaySpacing();
    }

}