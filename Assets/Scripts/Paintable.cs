using UnityEngine;

public class Paintable : MonoBehaviour
{   
    [Range(0,1)]
    public float OverlapThreshold = 0.75f;

    private new PolygonCollider2D collider;
    private Transform cameraTransform;

    private void Awake() {
        collider = GetComponent<PolygonCollider2D>();
        cameraTransform = Camera.main.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var extCollider = collision.collider;
        if(extCollider.CompareTag("Brush")) {
            print("Collided");
            var points = collider.points;
            var worldSpacePoints = new Vector2[points.Length];
            for(int i = 0; i < points.Length; ++i) {
                worldSpacePoints[i] = collider.transform.TransformPoint(points[i]);
            }

            int overlaps = 0;
            int count = worldSpacePoints.Length;
            foreach (var point in worldSpacePoints)
            {
                RaycastHit2D hit = Physics2D.Raycast(cameraTransform.position, point);
                if(hit) {
                    if(hit.collider.CompareTag("Brush"))
                        overlaps++;
                }

                // if(extCollider.OverlapPoint(point)) {
                //     overlaps++;
                // }
            }
            if(overlaps / count > OverlapThreshold)
                print("Overlapped successfully");
        }
    }
}
