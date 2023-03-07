using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce = 300;
    public Player2Controller player2Controller;
    public bool canJump = true;

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
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            //rb.MovePosition(transform.position+(Vector3.forward * speed * Time.deltaTime));
            //transform.Translate(Vector3.forward*speed* Time.deltaTime);
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(rb.velocity.x>-20f && rb.velocity.x < 20f)
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //rb.AddForce(Vector3.left * speed * Time.deltaTime);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x > -20f && rb.velocity.x < 20f)
            {
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
           // rb.AddForce(Vector3.right * speed * Time.deltaTime);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
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
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
    public void ChangeToBigSize()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "floor")
        {
            //Debug.Log("jebac disa");
            canJump = true;
        }
    }
}
