using UnityEngine;
using System.Collections;

public class matchControl : MonoBehaviour {

    public int matchType ; 

	// Use this for initialization
	void Start () {
        StartMatch(matchType);
	}

    public void StartMatch(int type)
    {
        switch (type)
        {
            case 0:
                GameObject champ = (GameObject)Instantiate(Resources.Load("Athlete"));
                champ.transform.position = new Vector3(2.2f, 2.5f, 0);
                champ.GetComponent<AthleteMovement>().baseSpeed = (Random.value * 10) + 5;
                champ.GetComponent<AthleteMovement>().abilityType = (int) Mathf.Floor(Random.value*2f);
                champ.GetComponent<AthleteMovement>().baseMass = Random.value * 2.5f;
                champ.GetComponent<AthleteMovement>().abilityPower = Random.value;
                champ.GetComponent<Rigidbody2D>().mass = champ.GetComponent<AthleteMovement>().baseMass;
                champ.GetComponent<AthleteMovement>().abilityCooldown = Random.value * 5;
                champ.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");

                GameObject champ2 = (GameObject)Instantiate(Resources.Load("Athlete"));
                champ2.transform.position = new Vector3(0, -2.8f, 0);
                champ2.GetComponent<AthleteMovement>().baseSpeed = (Random.value * 10) + 5;
                champ2.GetComponent<AthleteMovement>().abilityType = 0;
                champ2.GetComponent<AthleteMovement>().baseMass = Random.value * 2.5f;
                champ2.GetComponent<Rigidbody2D>().mass = champ2.GetComponent<AthleteMovement>().baseMass;
                champ2.GetComponent<AthleteMovement>().abilityCooldown = Random.value * 5;
                champ2.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");

                champ2.GetComponent<AthleteMovement>().opponent = champ;
                champ.GetComponent<AthleteMovement>().opponent = champ2;
                break;
        }
    }
}
