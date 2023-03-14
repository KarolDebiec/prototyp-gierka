using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce = 300;
    public float maxSpeed;
    public Player2Controller player2Controller;
    public bool canJump = true;

    public float recoveryRate;
    public float maxVirusValue;
    private float virusValue;

    public bool isSick;
    public Vector3 batteryPosition;
    public BatteryController batteryController;
    public bool haveBattery = false;
    // public TextMeshPro sickDisplay;

    public GameObject grabber;

    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ChangeToBigSize();
        virusValue = maxVirusValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.MovePosition(transform.position+(Vector3.forward * speed * Time.deltaTime));
            //transform.Translate(Vector3.forward*speed* Time.deltaTime);
            // rb.AddForce(Vector3.up * jumpForce);
            // canJump = false;
            if (rb.velocity.z > -maxSpeed && rb.velocity.z < maxSpeed)
            {
                rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(rb.velocity.x>-maxSpeed && rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //rb.AddForce(Vector3.left * speed * Time.deltaTime);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x > -maxSpeed && rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
           // rb.AddForce(Vector3.right * speed * Time.deltaTime);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.z > -maxSpeed && rb.velocity.z < maxSpeed)
            {
                rb.AddForce(Vector3.back * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false;
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
        /*if (Input.GetKeyDown(KeyCode.E) && isSick)
        {
            isSick = false;
            player2Controller.isSick = true;
            player2Controller.ChangeToBigSize();
            ChangeToSmallSize();
        }*/
        if (Input.GetKeyDown(KeyCode.V))
        {
           if (batteryController.player1InRadius && !batteryController.player2InRadius && !haveBattery)
           {
                batteryController.PickUpBattery(gameObject);
                haveBattery = true;
           }
           else if(haveBattery)
           {
                batteryController.DropBattery(gameObject);
                haveBattery = false;
           }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (haveBattery)
            {
                grabber.GetComponent<GrabController>().LaunchGrab();
            }
        }
        //sickDisplay.text = virusValue.ToString("F1");
    }
    public void ChangeToSmallSize()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
    public void ChangeToBigSize()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "floor" || collision.transform.tag == "Grabable")
        {
            //Debug.Log("jebac disa");
            canJump = true;
        }
    }
}
