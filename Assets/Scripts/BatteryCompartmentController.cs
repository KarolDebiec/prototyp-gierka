using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BatteryCompartmentController : MonoBehaviour
{
    public Vector3 holderPosition;
    public bool isBatteryNear;
    public TextMeshPro useTextDisplay;
    public bool isBatteryPlaced;
    public GameObject player;
    public GameObject battery;
    public GameObject doors;
    public Vector3 doorsTargetPosition;
    public float doorSpeed;
    private void Update()
    {
        if (isBatteryNear)
        {
            useTextDisplay.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.L))
            {
                isBatteryPlaced = true;
                if (player.transform.tag == "Player")
                {
                    player.GetComponent<Player1Controller>().haveBattery = false;
                    battery = player.GetComponent<Player1Controller>().batteryController.gameObject;
                    battery.transform.parent = gameObject.transform;
                    battery.transform.localPosition = holderPosition;
                }
                else if (player.transform.tag == "Player2")
                {
                    player.GetComponent<Player2Controller>().haveBattery = false;
                    battery = player.GetComponent<Player2Controller>().batteryController.gameObject;
                    battery.transform.parent = gameObject.transform;
                    battery.transform.localPosition = holderPosition;
                }
                isBatteryNear = false;
            }
        }
        else
        {
            useTextDisplay.gameObject.SetActive(false);
        }
        if(isBatteryPlaced)
        {
            doors.transform.position = Vector3.MoveTowards(doors.transform.position, doorsTargetPosition, Time.deltaTime * doorSpeed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if(other.GetComponent<Player1Controller>().haveBattery)
            {
                isBatteryNear = true;
                player = other.gameObject;
            }
        }
        if (other.transform.tag == "Player2")
        {
            if (other.GetComponent<Player2Controller>().haveBattery)
            {
                isBatteryNear = true;
                player = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.GetComponent<Player1Controller>().haveBattery)
            {
                isBatteryNear = false;
                player = null;
            }
        }
        if (other.transform.tag == "Player2")
        {
            if (other.GetComponent<Player2Controller>().haveBattery)
            {
                isBatteryNear = false;
                player = null;
            }
        }
    }
}
