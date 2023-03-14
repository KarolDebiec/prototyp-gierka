using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce = 300;
    public Player1Controller player1Controller;
    public bool canJump = true;
    public float maxSpeed;

    public float recoveryRate;
    public float maxVirusValue;
    private float virusValue;
    public bool isSick;

    public int maxJumps;
    private int jumps;

    public Vector3 batteryPosition;
    public BatteryController batteryController;
    public bool haveBattery = false;
    //public TextMeshPro sickDisplay;
    private Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ChangeToSmallSize();
        jumps = maxJumps;
        virusValue = maxVirusValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rb.MovePosition(transform.position + (Vector3.forward * speed * Time.deltaTime));
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //rb.AddForce(Vector3.up* jumpForce);
            //canJump = false;
            if (rb.velocity.z > -maxSpeed && rb.velocity.z < maxSpeed)
            {
                rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > -maxSpeed && rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //rb.AddForce(Vector3.left * speed * Time.deltaTime);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x > -maxSpeed && rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            // rb.AddForce(Vector3.right * speed * Time.deltaTime);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.z > -maxSpeed && rb.velocity.z < maxSpeed)
            {
                rb.AddForce(Vector3.back * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            if(haveBattery)
            {
                jumps--;
                if (jumps < 1)
                {
                    canJump = false;
                }
            }
            else
            {
                canJump = false;
            }
        }
        /* if (isSick)
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
         }*/
        /*if (Input.GetKeyDown(KeyCode.R) && isSick)
        {
            isSick = false;
            player1Controller.isSick = true;
            player1Controller.ChangeToBigSize();
            ChangeToSmallSize();
        }*/
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (batteryController.player2InRadius && !haveBattery)
            {
                batteryController.PickUpBattery(gameObject);
                haveBattery = true;
            }
            else if (haveBattery)
            {
                batteryController.DropBattery(gameObject);
                haveBattery = false;
            }
        }
        // sickDisplay.text = virusValue.ToString("F1") ;
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
        if (collision.transform.tag == "floor")
        {
            //Debug.Log("jebac disa");
            jumps = maxJumps;
            canJump = true;
        }
    }
}
