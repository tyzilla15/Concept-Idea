using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public Rigidbody MyBody;
    public float JumpForce;
    float Jump;
    public float FallTime;
    public float TurnSpeed;

    bool CanJump = true;

	// Use this for initialization
	void Start () {
        Jump = JumpForce;
    }
	
	// Update is called once per frame
	void Update () {

        Movement();
        Turning();
        Jumping();
        GravityControl();
        


	}

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        MyBody.velocity = transform.forward * Speed * z + transform.right * Speed * x + transform.up * MyBody.velocity.y;
    }

    void Turning()
    {

        float xrotate = Input.GetAxis("Mouse X");
        transform.Rotate(0, xrotate * TurnSpeed, 0);
    }

    void Jumping()
    {
        
        if (Input.GetKey(KeyCode.Space) && CanJump == true)
        {
            Jump = Jump + Time.deltaTime * 2;
            Debug.Log("Charging Jump, Current Force is: " + Jump);
        }

        if (Input.GetKeyUp(KeyCode.Space) && CanJump == true)
        {
            MyBody.velocity = new Vector3(MyBody.velocity.x, Jump, MyBody.velocity.z);
            CanJump = false;
            Jump = JumpForce;
        }
    }

    void GravityControl()
    {

        if (MyBody.velocity.y <= 0)
        {
            MyBody.velocity += Vector3.down * Time.deltaTime * FallTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            CanJump = true;
        }
    }
}
