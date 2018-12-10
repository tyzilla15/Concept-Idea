using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    public float MaxDistance;
    public Text T;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        bool HitTarget = Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, MaxDistance);
        Debug.Log(HitTarget);
        if (HitTarget && hit.collider.tag == "Interactable")
        {
            Debug.Log("Hit");
            T.enabled = true;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {

            }
        }
        else
        {
            T.enabled = false;
        }
    }
}
