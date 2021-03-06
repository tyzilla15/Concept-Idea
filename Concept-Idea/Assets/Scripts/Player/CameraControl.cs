﻿using System.Collections;
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

        Vector3 Rotation = transform.rotation.eulerAngles;

        float temp = Rotation.x;
        

        if (temp > 270 && temp < 360)
        {
            if(temp < 360 - MaxUp)
                temp = 300;
        }
        else if (temp > 0 && temp < 90)
        {
            if (temp > -MaxDown)
                temp = 60;
        }


        transform.eulerAngles = new Vector3(temp, Rotation.y, Rotation.z);

    }
}
