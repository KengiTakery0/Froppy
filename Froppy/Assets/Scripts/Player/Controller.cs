using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float Speed = 100f;
    [SerializeField] private float JumpForce = 100f;

    private bool isGrounded = false;
    private float horizonInput;

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
        if (Input.GetButton("Horizontal")) Moving();

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) Jump();
    }


    private void Moving()
    {
        horizonInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2((horizonInput * Speed * Time.deltaTime), body.velocity.y);

        //Change Direction
        spritRenderer.flipX = horizonInput < 0.1f;
    }
    private void Jump()
    {

        body.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);

    }
    private void ChecGround()
    {

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = col.Length > 1;

    }
}
