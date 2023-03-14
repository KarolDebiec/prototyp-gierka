using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GrabableController : MonoBehaviour
{

    public TextMeshPro textDisplay;
    public bool canPlayerPickup;
    public GameObject player;
    public bool isPickedup;
    private Transform original;
    public GameObject originalParent;
    private void Start()
    {
        original = transform;
        originalParent = transform.parent.gameObject;
    }
    void Update()
    {
        if(canPlayerPickup)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                isPickedup = true;
                canPlayerPickup = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                transform.parent = player.transform;
                textDisplay.gameObject.SetActive(false);
            }
        }
        if(isPickedup)
        {
            if (Input.GetKeyUp(KeyCode.M))
            {
                isPickedup = false;
                canPlayerPickup = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //transform.parent = original.parent;
                transform.parent = originalParent.transform;
            }
            textDisplay.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Player2")
        {
            canPlayerPickup = true;
            player = other.gameObject;
            textDisplay.gameObject.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Player2")
        {
            canPlayerPickup = false;
            player = null;
            textDisplay.gameObject.SetActive(false);
        }
    }
}
