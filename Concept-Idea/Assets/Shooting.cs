using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float GunDamage;
    public GameObject MuzzleFlash;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = Instantiate(MuzzleFlash, transform.position, Quaternion.identity);
            Destroy(go, .2f);
            RaycastHit hit;
            if (Physics.Raycast (Camera.main.transform.position, transform.forward, out hit))
            {
                hit.collider.gameObject.SendMessage("ApplyDamage", GunDamage);
                GameObject go1 = Instantiate(
                    hit.collider.gameObject.GetComponent<EnemyHealth>().HitEffect,
                    Camera.main.transform.position + Camera.main.transform.forward * hit.distance, 
                    Quaternion.identity);

                go1.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                go1.transform.parent = hit.collider.transform;
                Destroy(go1, hit.collider.gameObject.GetComponent<EnemyHealth>().BloodLength);
            }
        }
	}
}
