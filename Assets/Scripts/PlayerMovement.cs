using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int extraJumps;
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;

    private int jumpCounter;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private HealthManager healthManager;
    private float horizontalInput;
    private bool isDashing = false;
    private float dashEndTime;
    private float lastDashTime;

    private AudioManager audioManager;

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (healthManager.isDead)
        {
            return;
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
        anim.SetBool("Dashing", isDashing);

        if (!isDashing)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

        if (isGrounded())
        {
            jumpCounter = 0;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // Dash input and logic
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash())
        {
            StartDash();
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            // Keep dashing for the duration
            body.velocity = new Vector2(horizontalInput * dashSpeed, body.velocity.y);

            // End dash after duration
            if (Time.time >= dashEndTime)
            {
                isDashing = false;
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); // Resume normal speed
            }
        }
    }

    private void Jump()
    {
        if (isGrounded() || jumpCounter < extraJumps)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
            audioManager.PlaySFX(audioManager.jump);

            if (!isGrounded())
            {
                jumpCounter++;
            }
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool CanDash()
    {
        return Time.time >= lastDashTime + dashCooldown;
    }

    private void StartDash()
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        lastDashTime = Time.time;
        anim.SetTrigger("Dash");
        audioManager.PlaySFX(audioManager.dash);
    }

    public void PlayStep()
    {
        audioManager.PlaySFX(audioManager.steps);
    }
}
