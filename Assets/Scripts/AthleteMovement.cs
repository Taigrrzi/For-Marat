using UnityEngine;
using System.Collections;

public class AthleteMovement : MonoBehaviour
{
    public float baseSpeed;
    public float speed;
    public GameObject goal;
    public float abilityCooldown;
    public float abilityChance;
    public int abilityType;
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
        transform.FindChild("RedDot").localScale = (new Vector2(1f, 1f)) * (abilityTimer / abilityCooldown);
        if (abilityTimer <= 0)
        {
            abilityTimer = 0;
            if (abilityChance >= Random.value / Time.deltaTime)
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
                Debug.Log("Ability!");
                break;
            default:
                break;
        }
    }
}