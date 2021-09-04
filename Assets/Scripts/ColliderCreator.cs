using UnityEngine;

public class ColliderCreator : MonoBehaviour
{
    // Used to trigger a collision
    public void CreateCollider(GameObject obj) {
        var lineRenderer = obj.GetComponent<LineRenderer>();
        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        var count = obj.GetComponent<LineRenderer>().GetPositions(positions);
        var collider = obj.AddComponent<EdgeCollider2D>();
        
        Vector2[] points = new Vector2[count];
        for(int i = 0; i < count; i++) {
            points[i] = new Vector2(positions[i].x, positions[i].y);
        }
        collider.points = points;
        collider.edgeRadius = 0.18f;
        collider.isTrigger = true;
        // To be able to participate in collisions
        var rb = obj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
}