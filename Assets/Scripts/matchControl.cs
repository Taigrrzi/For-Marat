using UnityEngine;
using System.Collections;

public class matchControl : MonoBehaviour {

    public int matchType ; 

	// Use this for initialization
	void Start () {
	    switch (matchType)
        {
            case 0:
                GameObject champ = (GameObject) Instantiate(Resources.Load("Athlete"));
                champ.transform.position = new Vector3(0,2.5f,0);
                champ.GetComponent<AthleteMovement>().baseSpeed = (Random.value*10)+5;
                champ.GetComponent<AthleteMovement>().abilityChance = Random.value;
                champ.GetComponent<AthleteMovement>().abilityType = 0;
                champ.GetComponent<Rigidbody2D>().mass = Random.value*2.5f;
                champ.GetComponent<AthleteMovement>().abilityCooldown = 5;
                champ.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");

                GameObject champ2 = (GameObject)Instantiate(Resources.Load("Athlete"));
                champ2.transform.position = new Vector3(0, -2.5f, 0);
                champ2.GetComponent<AthleteMovement>().baseSpeed = (Random.value * 10) + 5;
                champ2.GetComponent<AthleteMovement>().abilityChance = Random.value;
                champ2.GetComponent<AthleteMovement>().abilityType = 0;
                champ2.GetComponent<Rigidbody2D>().mass = Random.value * 2.5f;
                champ2.GetComponent<AthleteMovement>().abilityCooldown = 5;
                champ2.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
                champ2.GetComponent<AthleteMovement>().opponent = champ;
                champ.GetComponent<AthleteMovement>().opponent = champ2;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
