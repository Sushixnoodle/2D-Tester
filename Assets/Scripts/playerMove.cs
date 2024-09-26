using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 7f; // Force of the jump
    private Rigidbody2D rb;

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
        float moveInput = Input.GetAxis("Horizontal"); // Get input from keyboard
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Move the player
    }

    private void Jump()
    {
        // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
        }
    }
}