using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CameraFollow cameraFollow = null;
    private CameraLookAt cameraLookAt = null;

    public enum CameraStates { idle, follow, lookAt, both };
    public CameraStates cameraState = CameraStates.idle; // Use in Update if changing through inspector
    private void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
        cameraLookAt = GetComponent<CameraLookAt>();

        SetCameraState(cameraState);
    }

    public void SetCameraState (CameraStates state)
    {
        switch ( state )
        {
            case CameraStates.idle:  StateIdle   ();  break;
            case CameraStates.follow:StateFollow ();  break;
            case CameraStates.lookAt:StateLookAt ();  break;
            case CameraStates.both:  StateBoth   ();  break;
        }
    }

    void StateIdle   () 
    {
        cameraFollow.enabled = false;
        cameraLookAt.enabled = false;
    }
    void StateFollow () 
    {
        cameraFollow.enabled = true;
        cameraLookAt.enabled = false;
    }
    void StateLookAt () 
    {
        cameraFollow.enabled = false; 
        cameraLookAt.enabled = true;
    }
    void StateBoth   () 
    {
        cameraFollow.enabled = true;
        cameraLookAt.enabled = true;
    }

}
