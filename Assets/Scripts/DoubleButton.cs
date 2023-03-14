using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton : MonoBehaviour
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
    public bool mainButtonActive;
    public bool secondButtonActive;
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
        if (openDoor)
        {
            doors.transform.Translate(Time.deltaTime * doorSpeed * Vector3.forward);
            if (doorLimit < doors.transform.position.z)
            {
                openDoor = false;
                canOpenDoor = false;
            }

        }
    }
    public void SecondButtonEntered()
    {
        secondButtonActive = true;
        if (mainButtonActive && secondButtonActive)
        {
            clickDisplay.SetActive(true);
            canOpenDoor = true;
        }
    }
    public void SecondButtonExited()
    {
        secondButtonActive = false;
        clickDisplay.SetActive(false);
        canOpenDoor = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        mainButtonActive = true;
        renderer.material = activeMaterial;
        if(mainButtonActive && secondButtonActive)
        {
            clickDisplay.SetActive(true);
            canOpenDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        mainButtonActive = false;
        renderer.material = inactiveMaterial;
        clickDisplay.SetActive(false);
        canOpenDoor = false;
    }
}
