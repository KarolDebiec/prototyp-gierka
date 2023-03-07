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

    public float recoveryRate;
    public float maxVirusValue;
    private float virusValue;
    public bool isSick;
    //public TextMeshPro sickDisplay;
    public Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeToSmallSize();
        virusValue = maxVirusValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            //rb.MovePosition(transform.position + (Vector3.forward * speed * Time.deltaTime));
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            rb.AddForce(Vector3.up* jumpForce);
            canJump = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > -20f && rb.velocity.x < 20f)
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //rb.AddForce(Vector3.left * speed * Time.deltaTime);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x > -20f && rb.velocity.x < 20f)
            {
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            //rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            // rb.AddForce(Vector3.right * speed * Time.deltaTime);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //rb.MovePosition(transform.position + (Vector3.back * speed * Time.deltaTime));
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.R) && isSick)
        {
            isSick = false;
            player1Controller.isSick = true;
            player1Controller.ChangeToBigSize();
            ChangeToSmallSize();
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
            canJump = true;
        }
    }
}
