using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    private void Start()
    {
        GameObject obj = new GameObject("new gameobject");

        GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereObj.transform.position = Vector3.one;
        sphereObj.AddComponent<Rigidbody>();
    }
}
