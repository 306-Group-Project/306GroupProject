using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update

    public bool ZoomActive;
    public Vector3[] Target;

    public Camera Cam;

    public float Speed; 
    
    void Start() {
        Cam = Carmera.main;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ZoomActive) {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, Speed);
        }
        else {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, Speed);
        }
    }
}
*/