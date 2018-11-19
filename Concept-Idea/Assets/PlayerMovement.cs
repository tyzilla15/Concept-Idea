using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody MyBody;
    public float JumpForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        MyBody.velocity = new Vector3(x * speed, y * speed, MyBody.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyBody.velocity = new Vector3(MyBody.velocity.x, MyBody.velocity.y, JumpForce);
        }
	}
}
