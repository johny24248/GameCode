using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target = null;
    public float smoothTime = 0.15f;
    public Vector3 offset = new Vector3(0.5f, -3, 6);

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - offset, smoothTime);
    }
}
