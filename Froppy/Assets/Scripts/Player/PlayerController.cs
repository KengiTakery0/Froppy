using UnityEngine;

enum PlayerState
{
    Idle,
    Run,
    Jump
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 4f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float ClimbingSpeed = 5f;



    private bool isWalled = false;
    private bool wallJump = false;

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


    private PlayerState State
    {
        get { return (PlayerState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
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
<<<<<<< HEAD
<<<<<<< HEAD
     
       

=======
>>>>>>> 6ca104d30f70822ebedd242a6bba51ebd6b557ca
=======
>>>>>>> 6ca104d30f70822ebedd242a6bba51ebd6b557ca
    }



    private void Update()
    {
        if (canJump) State = PlayerState.Idle;
        if (!canJump) State = PlayerState.Jump;


        ProcessMooving();
        ProcessJumping();
        ProcessClimbing();
       
    }



    private void ProcessMooving()
    {
        if (Input.GetButton("Horizontal")) Moving();
    }
    private void ProcessJumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            State = PlayerState.Jump; Jump();
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
        horizonInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2((horizonInput * Speed * Time.deltaTime), body.velocity.y);

        //Change Direction
        spriteRenderer.flipX = horizonInput < 0.1f;

        if (canJump) State = PlayerState.Run;
    }


    private void Jump()
    {
        if (canJump)
        {

            body.velocity = new Vector2(body.velocity.x, JumpForce);
            wallJump = false;

        }
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
