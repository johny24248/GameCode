using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraManager cameraManager = null;
    public CameraManager.CameraStates cameraState = CameraManager.CameraStates.idle;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name == "Cube")
        {
            cameraManager.SetCameraState ( cameraState );
        }
    }
}
