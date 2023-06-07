using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            Debug.Log("Player trigger, play animation");
            //animator.Play("floating");
            //animator.enabled = false;
            animator.SetBool("on", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            //animator.Play("spin");
            //animator.enabled = true;
            animator.SetBool("on", false);
        }
    }
}
