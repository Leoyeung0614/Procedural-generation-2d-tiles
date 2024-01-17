using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomLevel, minCamSize, maxCamSize;
    private Vector3 dragOrigin; // first click position

    private void PanCamera() {
        if (Input.GetMouseButtonDown(0)) {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)) {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }

    void ZoomIn() {
        float newSize = cam.orthographicSize + zoomLevel;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    void ZoomOut() {
        float newSize = cam.orthographicSize - zoomLevel;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    void Start() {
        cam.orthographicSize = 5;
        minCamSize = 2;
        maxCamSize = 8;
    }

    void Update() {
        PanCamera();
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            ZoomIn();
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            ZoomOut();
        }
    }
}
