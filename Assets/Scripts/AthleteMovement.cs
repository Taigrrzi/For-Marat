using UnityEngine;
using System.Collections;

public class AthleteMovement : MonoBehaviour
{
    public float baseSpeed;
    public float currentSpeed;
    public GameObject goal;
    public float abilityCooldown;
    public float abilityChance;
    public int abilityType;
    public float size;
    public GameObject opponent;
    public float baseHealth;
    public float abilityPower;
    public float currentHealth;
    public float baseMass;
    float abilityTimer;
    Vector2 direc;
    Rigidbody2D rbody;

    Vector2 oppodirec;
    Vector2 goaldirec;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color((1-GetComponent<SpriteRenderer>().color.r) + ((Random.value * 0.1f) - 0.2f), (1-GetComponent<SpriteRenderer>().color.g) + ((Random.value * 0.1f) - 0.2f), (1-GetComponent<SpriteRenderer>().color.b)+((Random.value*0.1f)-0.2f), 1.0f);
       
        /*    Finding Complementory Colours: 
        if colour = { "RR", "GG", "BB"}
        then colour.complement = { FF - "RR", FF - "GG", FF - "BB"}
        */

        currentSpeed = baseSpeed;
        currentHealth = baseHealth;
        abilityTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        size = ((rbody.mass) / (rbody.mass + 0.5f)) + 0.4f;
        transform.localScale = new Vector3(size*1.5f,size*1.5f,0f);
        transform.GetChild(0).localScale = (new Vector3(1f, 1f,0f)) * (abilityTimer / abilityCooldown);

        if (abilityTimer <= 0)
        {
            UseAbility();
            abilityTimer = abilityCooldown;
        
        } else
        {
            abilityTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (rbody.mass > baseMass)
        {
            rbody.mass = baseMass + ((rbody.mass - baseMass) * (abilityTimer / abilityCooldown));
        } else if (currentSpeed > baseSpeed)
        {
            currentSpeed = baseSpeed + ((currentSpeed-baseSpeed) * (abilityTimer / abilityCooldown));
        }


        oppodirec = (Vector2) (opponent.transform.position - transform.position);
        goaldirec = (Vector2) (goal.transform.position - transform.position);

        if (goaldirec.magnitude > ((Vector2)(goal.transform.position - opponent.transform.position)).magnitude)
        {
            direc = goaldirec;
        } else
        {
            direc = oppodirec;
        }
        direc.Normalize();
        rbody.AddForce(rbody.mass * direc * currentSpeed);
    }

    void UseAbility()
    {
        switch (abilityType)
        {
            case 0:
                rbody.mass *= (abilityPower * 1.5f) + 1f;
                break;
            case 1:
                currentSpeed *= (abilityPower * 1.5f) + 1f;
                break;
            default:
                break;
        }
    }
}