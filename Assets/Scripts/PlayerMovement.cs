using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    public bool isHidden;
    public static float hideDuration = 5f;
    public static float hideCooldown = 5f;

    public float hideTimer = 5f;
    public float hideCooldownTimer = 0f;

    public TextMeshProUGUI timerText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hideCooldownTimer < 0)
            {
                if (!isHidden)
                {
                    if (!(Input.GetAxis("Horizontal") != 0 || Input.GetKeyDown(KeyCode.Space)))
                    {
                        isHidden = true;
                        anim.Play("chameleon");
                        timerText.color = Color.grey;
                    }
                }
                else
                {
                    isHidden = false;
                    anim.Play("chameleon-");
                    timerText.color = Color.grey;
                }
            }
        }


        if (isHidden)
        {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetKeyDown(KeyCode.Space))
            {
                hideTimer = 0;
            }

            hideTimer -= Time.deltaTime;
            timerText.text = hideTimer.ToString("F1");
            if (hideTimer <= 0)
            {
                isHidden = false;
                anim.Play("chameleon-");
                hideTimer = hideDuration;
                hideCooldownTimer = hideCooldown;
                timerText.color = Color.blue;
            }
        }
        else
        {
            hideCooldownTimer -= Time.deltaTime;
            if (hideCooldownTimer < 0)
            {
                timerText.text = "Ability ready! \n" + hideTimer.ToString("F1");
                timerText.color = Color.green;
            }
            else
                timerText.text = hideCooldownTimer.ToString("F1");
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
