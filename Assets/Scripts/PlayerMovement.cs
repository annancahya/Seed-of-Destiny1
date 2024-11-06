using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] private int extraJumps;
    private int jumpCounter;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private HealthManager healthManager;
    private float horizontalInput;

    AudioManager audioManager;


    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Prevent rotation from physics
        body.freezeRotation = true;
    }

    private void Update()
    {
        if (healthManager.isDead)
        {
            return; // Skip the rest of the update if the player is dead
        }

        horizontalInput = Input.GetAxis("Horizontal");

        // Flip player when moving right & left
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        // Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());

        // Movement logic
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (isGrounded())
        {
            jumpCounter = 0;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (isGrounded() || jumpCounter < extraJumps)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
            audioManager.PlaySFX(audioManager.jump);

            // Increment jump counter if not grounded
            if (!isGrounded())
            {
                jumpCounter++; // Increment for additional jump
            }
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void PlayStep()
    {
        audioManager.PlaySFX(audioManager.steps);

    }

}
