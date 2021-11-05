using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float Speed = 100f;
    [SerializeField] private float JumpForce = 100f;

    private bool isGrounded = false;
    private float horizonInput;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        ChecGround();
    }
    private void Update()
    {


        if (Input.GetButton("Horizontal")) Moving();



        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();

        }



    }


    private void Moving()
    {
        horizonInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2((horizonInput * Speed * Time.deltaTime), body.velocity.y);

        //Change Direction
        if (horizonInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizonInput < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }
    }
    private void Jump()
    {

        body.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);

    }
    private void ChecGround()
    {

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = col.Length > 1f;

    }
}
