﻿using UnityEngine;
using System.Collections;

public class AthleteMovement : MonoBehaviour
{
    public float baseSpeed;
    public float speed;
    public GameObject goal;
    public float abilityCooldown;
    public float abilityChance;
    public int abilityType;
    public float size;
    public GameObject opponent;
    float abilityTimer;
    Vector2 direc;
    Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        speed = baseSpeed;
        abilityTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        size = ((rbody.mass) / (rbody.mass + 0.5f)) + 0.4f;
        transform.localScale = new Vector3(size,size,0f);
       // transform.GetChild(0).localScale = (new Vector3(1f, 1f,0f)) * (abilityTimer / abilityCooldown);

        if (abilityTimer <= 0)
        {
            abilityTimer = 0;
            if (abilityChance >= Random.value)
            {
                UseAbility();
                abilityTimer = abilityCooldown;
            }
        }
        else
        {
            abilityTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        direc = (Vector2)(goal.transform.position - transform.position);
        direc.Normalize();
        rbody.AddForce(rbody.mass * direc * speed);
    }

    void UseAbility()
    {
        switch (abilityType)
        {
            case 0:
                rbody.mass += 0.3f;
                break;
            default:
                break;
        }
    }
}