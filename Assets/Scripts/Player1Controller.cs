using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    public float speed;
    public Player2Controller player2Controller;

    public float recoveryRate;
    public float maxVirusValue;
    private float virusValue;

    public bool isSick;
    // public TextMeshPro sickDisplay;

    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeToBigSize();
        virusValue = maxVirusValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.MovePosition(transform.position+(Vector3.forward * speed * Time.deltaTime));
            transform.Translate(Vector3.forward*speed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        /*if(isSick)
        {
            virusValue -= Time.deltaTime;
        }
        else if(virusValue < maxVirusValue)
        {
            virusValue += Time.deltaTime * recoveryRate;
            if(virusValue > maxVirusValue)
            {
                virusValue = maxVirusValue;
            }
        }*/
        if (Input.GetKeyDown(KeyCode.E) && isSick)
        {
            isSick = false;
            player2Controller.isSick = true;
            player2Controller.ChangeToBigSize();
            ChangeToSmallSize();
        }
        //sickDisplay.text = virusValue.ToString("F1");
    }
    public void ChangeToSmallSize()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void ChangeToBigSize()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
