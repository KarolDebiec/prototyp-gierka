using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public Player1Controller player1Controller;

    public float recoveryRate;
    public float maxVirusValue;
    private float virusValue;
    public bool isSick;
    public TextMeshPro sickDisplay;
    public void Start()
    {
        virusValue = maxVirusValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (isSick)
        {
            virusValue -= Time.deltaTime;
        }
        else if (virusValue < maxVirusValue)
        {
            virusValue += Time.deltaTime * recoveryRate;
            if (virusValue > maxVirusValue)
            {
                virusValue = maxVirusValue;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && isSick)
        {
            isSick = false;
            player1Controller.isSick = true;
        }
        sickDisplay.text = virusValue.ToString("F1") ;
    }
}
