using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveKeys : MonoBehaviour
{
    public float speed = 5;
    public float rotateSpeed = 100;
    public Color colorChange = Color.white;
    public GameObject prefabWallHitParticle = null;
    public GameObject spherePrefab = null;
    public Transform socket = null;
    public float forceAmount = 400;
    public bool pauseMove = false;
    public bool clickToMove = true;
    public bool followMouse = true;
    public Camera cam = null;
    private Vector3 to;
    private Rigidbody rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if ( Input.GetKeyDown (KeyCode.Return))
        {
            GameObject obj = Instantiate(spherePrefab, socket.position, socket.rotation);
            obj.name = "Sphere";
            float rnd = Random.Range(0.35f, 1.0f);
            obj.transform.localScale = Vector3.one * rnd;

            obj.GetComponent<Rigidbody>().AddForce(socket.forward * forceAmount, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.UpArrow)&& !pauseMove)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if ( Input.GetKey (KeyCode.Q))
        {
            transform.Rotate( 0, -rotateSpeed * Time.deltaTime, 0);
        }
        else if ( Input.GetKey (KeyCode.E))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if ( Input.GetKeyDown (KeyCode.Z))
        {
            transform.localScale = Vector3.one * 0.5f;
            //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if ( Input.GetKeyDown (KeyCode.C))
        {
            //transform.localScale = Vector3.one;
            transform.localScale = new Vector3(1, 1, 1);           
        }

        if ( Input.GetKeyDown ( KeyCode.R))
        {
            GetComponent<Renderer>().material.color = colorChange;
        }

        if (clickToMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray;
                RaycastHit hit;

                ray = cam.ScreenPointToRay(Input.mousePosition);

                if ( Physics.Raycast ( ray, out hit, 100))
                {
                    if ( hit.collider )
                    {
                        to = hit.point;
                        to.y = transform.position.y;
                    }
                }
            }

            rb.MovePosition(Vector3.MoveTowards(transform.position, to, speed * Time.deltaTime));
        }
        if (followMouse)
        {
            Ray ray;
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast (ray, out hit, 100))
            {
                if (hit.collider)
                {
                    to = hit.point;
                    to.y = transform.position.y;
                    rb.MovePosition(Vector3.MoveTowards(transform.position, to, speed * Time.deltaTime));
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.name == "wallHit")
        {
            Instantiate(prefabWallHitParticle, this.transform.position, Quaternion.identity);
        }
    }
}
