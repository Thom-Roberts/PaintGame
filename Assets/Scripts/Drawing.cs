using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;
    private ColliderCreator creator;

    private void Awake() {
        creator = GetComponent<ColliderCreator>();
    }

    private void Start() {
        if(m_camera == null)
            m_camera = Camera.main;
    }

    private void Update() {
        Draw();
    }

    private void Draw() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            CreateBrush();
        }

        if(Input.GetKey(KeyCode.Mouse0)) {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos) {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else {
            if(currentLineRenderer != null) {
                creator.CreateCollider(currentLineRenderer.gameObject);
                // AddCollider();
                currentLineRenderer = null;
            }
        }
    }

    private void CreateBrush() {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    private void AddAPoint(Vector2 pos) {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pos);
    }

    // https://forum.unity.com/threads/how-to-add-collider-to-a-line-renderer.505307/
    // private void AddCollider() {
    //     var collider = currentLineRenderer.gameObject.AddComponent<PolygonCollider2D>();
    //     PolygonCollider2D col = new PolygonCollider2D();
        
    //     // var collider = currentLineRenderer.gameObject.AddComponent<MeshCollider>();
    //     // Mesh mesh = new Mesh();
    //     // currentLineRenderer.BakeMesh(mesh, true);
    //     // collider.sharedMesh = mesh;
    // }
}
