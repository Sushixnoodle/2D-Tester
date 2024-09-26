using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 7f; // Force of the jump
    private Rigidbody2D rb;
    private bool isGrounded; // To check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInputX = Input.GetAxis("Horizontal"); // Get input for horizontal movement
        float moveInputY = Input.GetAxis("Vertical"); // Get input for vertical movement
        rb.velocity = new Vector2(moveInputX * moveSpeed, rb.velocity.y); // Move the player horizontally

        // If you want to allow vertical movement without jumping, you can uncomment this:
        // rb.velocity = new Vector2(rb.velocity.x, moveInputY * moveSpeed);
    }

    private void Jump()
    {
        // Check for jump input and if the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
            isGrounded = false; // Set grounded to false after jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with the background
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is on the ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is no longer on the ground
        }
    }
}