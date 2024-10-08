using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;

    private float zoom;
    private float zoomMultiplier = 4.0f;
    private float minZoom = 0.2f;
    private float maxZoom = 2.25f;
    private float velocity = 0.0f;
    private float smoothTime = 0.25f;

    // Start is called before the first frame update

    private void Awake()
    {
  
    }

    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        while (true)
        {
            moveCam();
            yield return new WaitForSecondsRealtime(0.008f);
        }
    }

    public void moveCam()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            zoom -= 1 * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            zoom -= -1 * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        }
    }
}
