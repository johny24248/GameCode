using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExamples : MonoBehaviour
{
    public bool raycastSimple = true;
    public bool raycastPlaceObject = true;
    public bool raycastAll = true;
    public float distance = 4;
    public Camera cam;
    public GameObject raycastObj = null;
    private InputMoveKeys mover = null;
    private void Start()
    {
        mover = GetComponent<InputMoveKeys> ();
    }
    private void Update()
    {
        if ( raycastSimple )
        {
            Vector3 dir = this.transform.TransformDirection(Vector3.forward);

            Debug.DrawRay(this.transform.position, dir * distance, Color.red);

            mover.pauseMove = false;

            RaycastHit hit;

            if ( Physics.Raycast ( transform.position, dir, out hit, distance))
            {
                if ( hit.collider.name == "item")
                {
                    Debug.Log("Found item");
                    mover.pauseMove = true;
                    //hit.collider.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
        }
        else if ( raycastPlaceObject )
        {
            if ( Input.GetMouseButtonDown ( 0))
            {
                Ray ray;
                RaycastHit hit;

                ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                if (hit.collider != null)
                {
                    Instantiate(raycastObj, hit.point, Quaternion.identity);
                }
            }

            if ( raycastAll )
            {
                RaycastHit[] hits;

                hits = Physics.RaycastAll(transform.position, transform.forward, 100);

                for ( int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    Debug.Log("Hit:" + hit.collider.name);
                    Renderer rend = hit.transform.GetComponent<Renderer>();

                    if ( rend )
                    {
                        rend.material.color = Color.green;
                    }
                }
            }
        }
    }
}
