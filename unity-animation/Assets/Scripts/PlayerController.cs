using UnityEngine;

/// <summary>
/// Handles player movement using WASD and jumping with Spacebar.
/// Starts the Timer when the player first moves or jumps.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool hasMoved = false;

    private Timer timer; // reference to the Timer script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ✅ Start the timer on first movement OR jump
        if (!hasMoved && (Mathf.Abs(moveX) > 0.01f || Mathf.Abs(moveZ) > 0.01f || Input.GetKeyDown(KeyCode.Space)))
        {
            if (timer != null)
                timer.StartTimer();

            hasMoved = true;
        }

        MovePlayer(moveX, moveZ);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer(float moveX, float moveZ)
    {
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 velocity = move * moveSpeed;
        velocity.y = rb.linearVelocity.y; // retain vertical velocity
        rb.linearVelocity = velocity;
    }

    public void PauseTimer()
    {
        enabled = false; // Stops Update() from running
    }

    public void ResumeTimer()
    {
        enabled = true; // Resumes Update() so timer continues
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
