using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour
{
    public Transform target = null;
    public bool followMove = true;
    public bool followRotate = true;
    public float offset = 7.0f;
    private Camera minimap = null;
    private bool fullscreen = false;
    private void Start()
    {
        minimap = GetComponent<Camera>();
    }
    private void Update()
    {
        if ( Input.GetKeyDown (KeyCode.M))
        {
            if ( fullscreen )
            {
                minimap.rect = new Rect(0.01f, 0.0f, 0.2f, 0.35f);
            }
            else
            {
                minimap.rect = new Rect(0, 0, 1, 1);
            }

            fullscreen = !fullscreen;
                     
        }
    }
    private void LateUpdate()
    {
        if ( followMove )
        {
            transform.position = new Vector3 (target.position.x, offset, transform.position.z);
        }

        if ( followRotate )
        {
            //transform.rotation = target.rotation;
            transform.rotation = Quaternion.Euler( 90, target.eulerAngles.y, 0);
        }
    }
}
