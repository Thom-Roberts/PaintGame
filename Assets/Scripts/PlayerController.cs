using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float jumpForce = 5f;
    public bool isGrounded = true;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newTransform = transform.position;
        if(Input.GetKey(KeyCode.LeftArrow)) {
            newTransform.x -= walkSpeed * Time.deltaTime;
            // rb.velocity = Vector2.left * walkSpeed;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            newTransform.x += walkSpeed * Time.deltaTime;
            // rb.velocity = Vector2.right * walkSpeed;
        }
        transform.position = newTransform;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
