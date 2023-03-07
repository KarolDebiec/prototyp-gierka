using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;
    private Renderer renderer; 
    public GameObject clickDisplay;
    private bool canOpenDoor = false;
    private bool openDoor = false;
    public GameObject doors;
    public float doorSpeed;
    public float doorLimit;
    public GameObject doors2;
    public float door2Speed;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }
    private void Update()
    {
        if (canOpenDoor && !openDoor)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                openDoor = true;
                canOpenDoor = false;
            }
        }
        if(openDoor)
        {
            doors.transform.Translate(Time.deltaTime * doorSpeed * Vector3.forward);
            doors2.transform.Translate(Time.deltaTime * door2Speed * Vector3.up);
            if (doorLimit < doors.transform.position.z)
            {
                openDoor = false;
                canOpenDoor = false;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        renderer.material = activeMaterial;
        clickDisplay.SetActive(true);
        Debug.Log("entered");
        canOpenDoor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        renderer.material = inactiveMaterial;
        clickDisplay.SetActive(false);
        Debug.Log("exited");
        canOpenDoor = false;
    }
}
