using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 originalPosition;
    public GameObject platformObject;
    public bool isPressed;
    public float speed;
    public bool isPressedByPlayer;
    public bool isPressedByMoveable; 
    public bool isPressedByBattery;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = platformObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressedByPlayer || isPressedByMoveable || isPressedByBattery)
        {
            platformObject.transform.position = Vector3.MoveTowards(platformObject.transform.position, targetPosition, Time.deltaTime*speed);
        }
        else
        {
            platformObject.transform.position = Vector3.MoveTowards(platformObject.transform.position, originalPosition, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" || other.transform.tag == "Player2")
        {
            isPressedByPlayer = true;
        }
        if (other.transform.tag == "Battery")
        {
            isPressedByBattery = true;
        }
        if (other.transform.tag == "Grabable")
        {
            isPressedByMoveable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Player2")
        {
            isPressedByPlayer = false;
        }
        if (other.transform.tag == "Battery")
        {
            isPressedByBattery = false;
        }
        if (other.transform.tag == "Grabable")
        {
            isPressedByMoveable = false;
        }
    }
}
