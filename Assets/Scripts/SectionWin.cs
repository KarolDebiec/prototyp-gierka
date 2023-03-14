using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SectionWin : MonoBehaviour
{
    public GameController gameController;
    public bool player1Reached = false;
    public bool player2Reached = false;
    public int scenesAmount;
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
            //gameController.Win();
            if(scenesAmount > SceneManager.GetActiveScene().buildIndex + 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
    
}
