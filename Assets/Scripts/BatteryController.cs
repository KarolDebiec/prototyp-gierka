using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryController : MonoBehaviour
{
    public TextMeshPro pickupDisplay;
    public bool player1InRadius = false;
    public bool player2InRadius = false;
    public bool isPickedUp = false;
    public SphereCollider sphereCollider1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!isPickedUp)
        {
            if (other.transform.tag == "Player")
            {
                player1InRadius = true;
            }
            if (other.transform.tag == "Player2")
            {
                player2InRadius = true;
            }
            if (player1InRadius || player2InRadius)
            {
                pickupDisplay.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!isPickedUp)
        {
            if (other.transform.tag == "Player")
            {
                player1InRadius = false;
            }
            if (other.transform.tag == "Player2")
            {
                player2InRadius = false;
            }
            if (!player1InRadius && !player2InRadius)
            {
                pickupDisplay.gameObject.SetActive(false);
            }
        }
    }
    public void PickUpBattery(GameObject player)
    {
        isPickedUp = true;
        if (player.transform.tag == "Player")
        {
            transform.parent = player.transform;
            transform.localPosition = player.GetComponent<Player1Controller>().batteryPosition;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity= false;
            sphereCollider1.enabled = false;
            pickupDisplay.gameObject.SetActive(false);
        }
        if (player.transform.tag == "Player2")
        {
            transform.parent = player.transform;
            transform.localPosition = player.GetComponent<Player2Controller>().batteryPosition;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            sphereCollider1.enabled = false;
            pickupDisplay.gameObject.SetActive(false);
        }
    }
    public void DropBattery(GameObject player)
    {
        isPickedUp = false;
        transform.parent = player.transform.parent;
        //transform.position = player.GetComponent<Player1Controller>().batteryPosition;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        sphereCollider1.enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
