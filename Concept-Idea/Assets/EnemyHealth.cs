using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float Health;
    public GameObject HitEffect;
    public float BloodLength;
    Rigidbody Body;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void ApplyDamage (float Damage)
    {
        Health = Health - Damage;
        if (Health <= 0)
        {
            Body.freezeRotation = false;
        }
    }
}
