using UnityEngine;
using UnityEngine.InputSystem;

public class BlobMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    
    [SerializeField] public float speed = 100f;
    [SerializeField] public float jumpingPower = 12f;
    private float horizontal;
    private bool isFacingRight = true;


    void Update()
    {

        if(!isFacingRight && horizontal > 0f)
        {
            flip();
            Blob.direction = 1;
        }
        else if(isFacingRight && horizontal < 0f)
        {
            flip();
            Blob.direction = -1;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rb.linearVelocity.y);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if(context.canceled && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }


    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        
        horizontal = context.ReadValue<Vector2>().x;

    }
}
