using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Initial speed of the player
    private Rigidbody2D body;
    private Animator runnimator;
    private bool grounded;
    
    private void Awake()
    {
        // Grab references for Rigidbody and Animator from the GameObject
        body = GetComponent<Rigidbody2D>();
        runnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        // Flip player when moving left or right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Handle jump if player is grounded
        if (Input.GetKey(KeyCode.L) && grounded)
            Jump();
        
        // Set animator parameters for running and grounded states
        runnimator.SetBool("run", horizontalInput != 0);
        runnimator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        // Apply jump by setting vertical velocity using speed
        body.velocity = new Vector2(body.velocity.x, speed);
        runnimator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    // Method to increase player speed when collecting speed boost items
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
        Debug.Log("New Speed: " + speed); // To log new speed
    }
}