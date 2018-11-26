using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float NodSpeed;
    public float MaxUp = 60;
    public float MaxDown = -60;

    float yrotate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        yrotate = Input.GetAxis("Mouse Y")* NodSpeed;
        //yrotate = Mathf.Clamp(yrotate, MaxDown, MaxUp);
        
        transform.Rotate(yrotate, 0, 0);
    }
}
