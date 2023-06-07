using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public int hitpoints = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere")
        {
            hitpoints--;
            if ( hitpoints <= 0 )
            {
                Destroy(this.gameObject);
            }


        }
    }
}
