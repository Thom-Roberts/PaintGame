using UnityEngine;

public class Paintable : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Brush")) {
            print("Collided");
        }
    }
}
