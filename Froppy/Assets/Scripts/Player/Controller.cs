using UnityEngine;

enum PlayerState
{
    Idle,
    Run,
    Jump
}
public class Controller : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 6f;

    private bool isGrounded = false;
    private float horizonInput;

    private PlayerState State
    {
        get { return (PlayerState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer spritRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        ChecGround();
    }

    private void Update()
    {
       
        if (isGrounded) State = PlayerState.Idle;

        if (Input.GetButton("Horizontal")) Moving();

        if (Input.GetButtonDown("Jump") && isGrounded) Jump();

        if (Input.GetButton("Horizontal") && (Input.GetButtonDown("Jump") && isGrounded)) MegaJump();
     }


    private void Moving()
    {
        horizonInput = Input.GetAxis("Horizontal");
        Vector3 direction = transform.right * horizonInput;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime); 

        //Change Direction
        spritRenderer.flipX = direction.x < 0.0f;

        if (isGrounded) State = PlayerState.Run;
    }
    private void Jump()
    {
        body.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    private void MegaJump()
    {
        body.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }
    private void ChecGround()
    {

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = col.Length > 1;

        if (!isGrounded) State = PlayerState.Jump;

    }


}
