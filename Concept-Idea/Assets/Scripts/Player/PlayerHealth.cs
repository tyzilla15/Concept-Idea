﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float Health;
    public GameObject HitEffect;
    Rigidbody Body;
    public float HitFrame;
    float TimeStamp;
    public GameObject Blood1;
    public GameObject Blood2;

    float Alpha = 255;


    void Start()
    {
        Body = GetComponent<Rigidbody>();
        HealthBar.maxValue = Health;
    }

    private void Update()
    {
        if (Alpha > 62)
        {
            Blood1.GetComponent<Image>().color = new Color(1, 1, 1, Alpha/255);
            Alpha = Alpha - Time.deltaTime * 10;
        }
    }

    void ApplyDamage(float Damage)
    {
        if (TimeStamp + HitFrame <= Time.time)
        {
            TimeStamp = Time.time;
            Health = Health - Damage;
            HealthBar.value = Health;

            if (Health == 2)
            {
                Blood1.SetActive(true);
                Blood1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                Alpha = 255;

            }
            if (Health == 1)
            {
                Blood1.SetActive(false);
                Blood2.SetActive(true);
            }
            if (Health <= 0)
            {
            Body.freezeRotation = false;
            }
        }
      
    }
}