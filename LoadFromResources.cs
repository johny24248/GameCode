using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromResources : MonoBehaviour
{
    private void Start()
    {
        GameObject obj = Resources.Load("Prefabs/Capsule") as GameObject;
        Instantiate(obj);
    }
}
