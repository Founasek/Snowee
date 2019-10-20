using UnityEngine;


//This scrits makes the character move when the screen is pressed and handles the jump
public class PlayerMovement : MonoBehaviour
{

    public bool jump = false;               // Condition for whether the player should jump.
    public float moveSpeed;
    public float jumpForce;

    public float acceleration = 0.5f;
    public float maxSpeed = 20f;

    private Rigidbody2D myRigidBody;
    private bool grounded = false;          // Whether or not the player is grounded.
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        moveSpeed += (acceleration * Time.deltaTime) / 15f;

        if(moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }

        if (Input.touchCount > 0)
        { 

        if (Input.GetTouch(0).position.x <Screen.width /2)
        {
                Debug.Log("Left side");
                

                if (grounded == true)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                    grounded = false;
                    animator.SetTrigger("Player_jump");
                }
            }
        else
        {
                Debug.Log("Right side");
            }

    }

    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        grounded = true;
    }
  

    public void gojump()
    {
        if (grounded == true)
        {
            jump = true;
            grounded = false;
            animator.SetTrigger("Player_jump");
            return;
        }
        

    }

    void FixedUpdate()
    {
        if (jump == true)
        {
            // Add a vertical force to the player.
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
        jump = false;
    }
}


/*
    public int movementSpeed = 10;          // The vertical speed of the movement
    public float jumpForce = 10.0f;         // Amount of force added when the player jumps. 
    public bool MoveRight = false;
    public bool MoveLeft = false;
    



    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        grounded = true;
    }
*/

/*
public void onPointerDownMoveRightButton()
{
    MoveRight = true;
}

public void onPointerUpMoveRightButton()
{
    MoveRight = false;
}

public void onPointerDownMoveLeftButton()
{
    MoveLeft = true;
}

public void onPointerUpMoveLeftButton()
{
    MoveLeft = false;
}

public void gojump()
{
    if (grounded == true)
    {
        jump = true;
        grounded = false;
        animator.SetTrigger("Player_jump");
        candoublejump = true;
    }
    else
    {
        if (candoublejump)
        {
        candoublejump = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce / 1.2f), ForceMode2D.Impulse);
        }
    }

}

//Since we are using physics for movement, we use the FixedUpdate method
void FixedUpdate()
{









            if (MoveRight == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }

            if (jump == true)
            {
                // Add a vertical force to the player.
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  
            }
            jump = false;
        }

}
}

*/
     