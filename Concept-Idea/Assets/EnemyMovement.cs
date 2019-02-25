using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject Player;
    public float Speed;
    Rigidbody Body;
    public float MaxDistance;

	// Use this for initialization
	void Start () {
        Body = GetComponent<Rigidbody>();
	}
	
    void ChasePlayer()
    {
        Vector3 Velocity = new Vector3 (Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z);
        Velocity = Velocity.normalized;
        Velocity = Speed * Velocity;
        Velocity = new Vector3(Velocity.x, Body.velocity.y, Velocity.z);
        Body.velocity = Velocity;
    }

    void Direction()
    {
        Vector3 Velocity = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z);
        transform.forward = Velocity.normalized;
    }

    void DetectPlayer()
    {
        RaycastHit hit;
        bool HitTarget = Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance);
        if (HitTarget && hit.collider.tag == "Player")
        {
            if (GetComponent<EnemyHealth>().Health >= 0)
            {
                ChasePlayer();
                Direction();
            }

        }
    }

    // Update is called once per frame
    void Update () {
        DetectPlayer();
	}
}
