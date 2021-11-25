using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 4f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float ClimbingSpeed = 5f;



    private bool isWalled = false;
    private bool wallJump = false;
    private bool is_FacingRight = true;


    private float horizonInput;
    private float verticalInput;
    private GroundChecker[] groundChecers;

    private bool canJump
    {
        get
        {
            if (wallJump) return true;
            else
            {
                foreach (GroundChecker c in groundChecers) if (c.isGrounded()) return true;
            }
            return false;
        }
    }



    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        groundChecers = GetComponentsInChildren<GroundChecker>();
    }



    private void FixedUpdate()
    {
        Debug.Log(horizonInput);
       // Debug.Log();

        ProcessMooving();
        ProcessClimbing();
        ProcessJumping();
    }

    private void ProcessMooving()
    {
        Moving();
    }

    private void ProcessJumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
             Jump();
        }
    }
    private void ProcessClimbing()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetButton("Vertical") & isWalled)
        {
            body.AddForce(new Vector2(0, ClimbingSpeed * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    private void Moving()
    {
        horizonInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizonInput));
        
        body.velocity = new Vector2((horizonInput * Speed * Time.deltaTime), body.velocity.y);
        //spriteRenderer.flipX = horizonInput == -1f;
        if(horizonInput < 0 && is_FacingRight)
        {
            Flip();
        }
        else if (horizonInput > 0 && !is_FacingRight) Flip();
    }


    private void Jump()
    {
        if (canJump)
        {

            body.velocity = new Vector2(body.velocity.x, JumpForce);
            wallJump = false;

        }
    }

    private void Flip()
    {
        is_FacingRight = !is_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void setWalled(bool walled)
    {
        this.isWalled = walled;
    }

    public void SetCanJumpfromWall(bool canJump)
    {
        wallJump = canJump;
    }



}
