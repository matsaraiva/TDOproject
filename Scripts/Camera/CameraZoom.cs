using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private Camera cameraFreeWalk;
    public float zoomSpeed = 20f;
    public float minZoomFOV = 10f;
    public float maxZoomFOV = 160f;

    private void Awake()
    {
        cameraFreeWalk = GetComponent<Camera>();
        Assert.IsNotNull(cameraFreeWalk);
        Assert.IsFalse(cameraFreeWalk.orthographic, "There isn't a FOV on an orthographic camera.");
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut();
        }

    }

    public void ZoomIn()
    {
        cameraFreeWalk.fieldOfView -= zoomSpeed;
        if (cameraFreeWalk.fieldOfView < minZoomFOV)
        {
            cameraFreeWalk.fieldOfView = minZoomFOV;
        }
    }


    public void ZoomOut()
    {
        cameraFreeWalk.fieldOfView += zoomSpeed;
        if (cameraFreeWalk.fieldOfView > maxZoomFOV)
        {
            cameraFreeWalk.fieldOfView = maxZoomFOV;
        }
    }
    
}
