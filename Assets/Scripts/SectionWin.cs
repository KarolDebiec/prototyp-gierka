using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionWin : MonoBehaviour
{
    public GameController gameController;
    public bool player1Reached = false;
    public bool player2Reached = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            player1Reached = true;
        }
        if (other.transform.tag == "Player2")
        {
            player2Reached = true;
        }
        if (player1Reached && player2Reached)
        {
            gameController.Win();
        }
    }
    
}
