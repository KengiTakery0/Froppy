using UnityEngine;

enum PlayerState
{
    Idle,
    Run,
    Jump
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 100f;
    [SerializeField] private float JumpForce = 100f;
    [SerializeField] private float ClimbingSpeed = 100f;

    private bool isWalled = false;
    private bool WallJump = false;

    private float horizonInput;
    private GroundChecer[] groundChecers;

    private bool canJump
    {
        get
        {
            if (WallJump) return true;
            else
            {
                foreach (GroundChecer c in groundChecers) if (c.isGrounded()) return true;
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
    private SpriteRenderer spritRenderer;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritRenderer = GetComponent<SpriteRenderer>();
        groundChecers = GetComponentsInChildren<GroundChecer>();

    }



    private void Update()
    {
        if (canJump) State = PlayerState.Idle;


        ProcessMooving();
        ProcessJumping();

    }

    private void ProcessMooving()
    {
        if (Input.GetButton("Horizontal")) Moving();
    }
    private void ProcessJumping()
    {
        if (Input.GetButtonDown("Jump") && canJump) Jump();
    }
    private void Moving()
    {
        horizonInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2((horizonInput * Speed * Time.deltaTime), body.velocity.y);

        //Change Direction
        spritRenderer.flipX = horizonInput < 0.1f;

        if (canJump) State = PlayerState.Run;
    }
    private void Jump()
    {
        if (canJump)
        {
            body.velocity = new Vector2(body.velocity.x, JumpForce);
            WallJump = false;
        }
    }

    public void setWalled(bool walled)
    {
        this.isWalled = walled;
    }
    /*private void ChecGround()
    {

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = col.Length > 1;

        if (!isGrounded) State = PlayerState.Jump;

    }*/


}
