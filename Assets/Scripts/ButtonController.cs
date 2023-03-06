using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        renderer.material = activeMaterial;
        Debug.Log("entered");
    }
    private void OnTriggerExit(Collider other)
    {
        renderer.material = inactiveMaterial;
        Debug.Log("exited");
    }
}
