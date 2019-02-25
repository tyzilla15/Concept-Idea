using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{

    public float MaxDistance;
    public Text T;
    GameObject HeldObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        bool HitTarget = Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, MaxDistance);
        if (HitTarget && hit.collider.tag == "Interactable")
        {
            T.enabled = true;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                HeldObject = hit.collider.gameObject;
            }

        }

        else if (HitTarget && hit.collider.tag == "Door")

        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().SetBool("Open",
                    !hit.collider.gameObject.GetComponentInParent<Animator>().GetBool("Open"));
            }
        }

        else if (HitTarget && hit.collider.tag == "Key")
        {
            if (Input.GetKey(KeyCode.E) && hit.collider.name == "Key1")
            {
                Inventory.Key1 = true;
                Destroy(hit.collider.gameObject);
            }
   
        }

        else
        {
            T.enabled = false;
        }

        if (Input.GetKey(KeyCode.Mouse1) && HeldObject != null)
            {
                
                HeldObject.transform.position = transform.position + transform.forward * 2;
                HeldObject.GetComponent<Rigidbody>().useGravity = false;
                T.enabled = false;

            }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            HeldObject.GetComponent<Rigidbody>().useGravity = true;
            HeldObject = null;
        }
    }

}
