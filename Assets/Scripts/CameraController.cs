using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 offset;
    public float disMultiplier;
    public float minDistance;
    private float dist;
    void Update()
    {
        dist = Vector3.Distance(player1.transform.position, player2.transform.position);
        if (dist < minDistance)
        {
            disMultiplier = 1;
        }
        else
        {
            disMultiplier = dist/minDistance;
        }
        //Debug.Log(Vector3.Distance(player1.transform.position, player2.transform.position));
        transform.position = offset * disMultiplier + ((player1.transform.position+ player2.transform.position)/2);
    }
}
