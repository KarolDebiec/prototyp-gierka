using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float grabberSpeed;
    public float grabberDistance;
    private float gDist;
    public float grabberBackSpeed;
    public bool launched = false;
    public bool moveBack = false;
    private bool canGrab = false;
    private Vector3 originalPos;
    public GameObject grabbedObject;
    public GameObject grabableParent;
    private void Start()
    {
        gDist = grabberDistance;
        originalPos = transform.localPosition;
    }
    private void Update()
    {
        if(launched)
        {
            transform.Translate(Vector3.right * grabberSpeed * Time.deltaTime);
            gDist -= grabberSpeed * Time.deltaTime;
        }
        if (moveBack)
        {
            transform.Translate(Vector3.left * grabberBackSpeed * Time.deltaTime);
            gDist -= grabberBackSpeed * Time.deltaTime;
        }
        if(gDist < 0 && launched)
        {
            launched = false;
            moveBack = true;
            canGrab = false;
            gDist = grabberDistance;
        }
        if (moveBack && gDist < 0 && !launched)
        {
            launched = false;
            moveBack = false;
            gDist = 0;
            transform.localPosition = originalPos;
            if (grabbedObject != null)
            {
                grabbedObject.transform.parent = grabableParent.transform;
                grabbedObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
    public void LaunchGrab()
    {
        if (!moveBack && !launched)
        {
            gDist = grabberDistance;
            launched = true;
            canGrab = true;
            transform.localPosition = originalPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Grabable" && canGrab)
        {
            grabbedObject = other.gameObject;
            grabbedObject.transform.parent = gameObject.transform;
            grabbedObject.transform.localPosition = transform.localPosition + new Vector3(0.2f,0,0);
            grabbedObject.GetComponent<BoxCollider>().enabled = false;
            canGrab = false;
            gDist = grabberDistance;
            launched = false;
            moveBack = true;
        }
    }
}
