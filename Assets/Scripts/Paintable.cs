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

    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger entered");
        if(TestCovered(other)) {
            print("Success");
        }
        else
            print("Failure");
    }

    public bool TestCovered(Collider2D otherCollider) {
        var points = collider.points;
        var worldSpacePoints = new Vector2[points.Length];
        for(int i = 0; i < points.Length; ++i) {
            worldSpacePoints[i] = collider.transform.TransformPoint(points[i]);
        }

        int overlaps = 0;
        int count = worldSpacePoints.Length;
        
        // Test using the mesh bounds of the line
        var line = otherCollider.GetComponent<LineRenderer>();
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, true);
        foreach (var point in worldSpacePoints)
        {
            if(mesh.bounds.Contains(point))
                overlaps++;
        }
        if(overlaps / count > OverlapThreshold)
            return true;
        else
            return false;
    }
}
