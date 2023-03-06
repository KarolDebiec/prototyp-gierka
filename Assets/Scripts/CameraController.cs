using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 offset;

    void Update()
    {
        transform.position = offset + ((player1.transform.position+ player2.transform.position)/2);
    }
}
