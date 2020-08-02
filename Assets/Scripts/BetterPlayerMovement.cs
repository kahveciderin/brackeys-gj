using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (BetterController))]
public class BetterPlayerMovement : MonoBehaviour {

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




	void Start() {
		controller = GetComponent<BetterController> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        animator = GetComponent<Animator>();

        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playermovs.Push(gameObject.transform.position);
        lastRecorded = Time.time;
        ToAdult();


		//print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update() {

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

    if(!stop){
        Vector2 input;
        if(isBaby){
        input = new Vector2(1,0);
        }else{

		input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
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
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);


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


        collider.offset = new Vector2(0, -.055f);
        collider.size = new Vector2(.07f, .05f);
        spriteRenderer.sprite = spriteBaby;
        isBaby = true;

        for (int i = 0; i < babymovs.Count; i++)
        {
            Vector2 playbackthis = babymovs.Pop();
            Vector2 deltaPos = playbackthis - previousPos;

            for (int j = 1; j < interpolaiton + 1; j++)
            {
                Vector2 addThis = j * (deltaPos / new Vector2(interpolaiton, interpolaiton));
                gameObject.transform.position = previousPos + addThis;
                yield return new WaitForSeconds(playSpeed);
            }

            previousPos = playbackthis;
        }


        stop = false;
        revEffect.SetActive(false);
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
        collider.offset = new Vector2(0, 0);
        collider.size = new Vector2(.07f, .16f);
        //spriteRenderer.sprite = spriteAdult;
        isBaby = false;
    }

}