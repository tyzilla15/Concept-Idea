using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float Health;
    public GameObject HitEffect;
    public float BloodLength;
    
    void ApplyDamage (float Damage)
    {
        Health = Health - Damage;
    }
}
