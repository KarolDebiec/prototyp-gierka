using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 offset;
    public float disMultiplier;

    void Update()
    {
       // Vector3.Distance(player1.transform.position, player2.transform.position);
        transform.position = offset + ((player1.transform.position+ player2.transform.position)/2);
    }
}
