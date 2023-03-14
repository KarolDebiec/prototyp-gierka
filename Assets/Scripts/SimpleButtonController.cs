using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonController : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;
    private Renderer renderer;
    public DoubleButton mainButton;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        mainButton.SecondButtonEntered();
        renderer.material = activeMaterial;
    }
    private void OnTriggerExit(Collider other)
    {
        mainButton.SecondButtonExited();
        renderer.material = inactiveMaterial;
    }
}
