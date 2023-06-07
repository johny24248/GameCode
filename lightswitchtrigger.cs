using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightswitchtrigger : MonoBehaviour
{
    public GameObject lightObj = null;
    public GameObject particleObj = null;
    public GameObject doorObj = null;
    public AudioSource doorOpenAudio = null;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name == "Cube" )
        {
            GetComponent<AudioSource>().Play();

            lightObj.SetActive(true);

            StartCoroutine(PlayParticle());
        }
    }
    
    IEnumerator PlayParticle ()
    {
        yield return new WaitForSeconds(1);

        particleObj.SetActive(true);

        doorOpenAudio.Play();

        LeanTween.move(doorObj, doorObj.transform.position - new Vector3(0, 3, 0), 2);
    }
    private void OnTriggerExit(Collider other)
    {
        if ( other.name == "Cube")
        {
            lightObj.SetActive(false);
        }
    }
}
