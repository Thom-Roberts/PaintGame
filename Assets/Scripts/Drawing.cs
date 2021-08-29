using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;
    
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
            currentLineRenderer = null;
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
}
