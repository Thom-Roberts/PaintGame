using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            rb.velocity = Vector2.left * walkSpeed;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            rb.velocity = Vector2.right * walkSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
