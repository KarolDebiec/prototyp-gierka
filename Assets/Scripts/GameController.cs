using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    //public float startingSectionTime;
    //private float sectionTime;
    //public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI endDisplay;
    public bool sectionEnded;
    void Start()
    {
        //ectionTime = startingSectionTime;
    }
    void Update()
    {
        /*if(!sectionEnded)
        {
            sectionTime -= Time.deltaTime;
            timeDisplay.text = sectionTime.ToString("F1");
            if (sectionTime < 0)
            {
                Lose();
            }
        }*/
    }
    public void Lose()
    {
        sectionEnded = true;
        endDisplay.text = "You lose";
    }
    public void Win()
    {
        sectionEnded = true;
        endDisplay.text = "You win";
    }
}
