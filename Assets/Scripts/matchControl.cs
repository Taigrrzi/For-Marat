using UnityEngine;
using System.Collections;

public class matchControl : MonoBehaviour {

    public int matchType ;
    public string[] athleteIDs;
    public int athleteAmount ;
    public int matchTimer;
    public int matchDuration;
    public GameObject athlete1;
    public GameObject athlete2;
    // Use this for initialization
    void Start () {
        matchTimer = 0;
        athleteIDs = new string[athleteAmount];
        for (int i=0;i<athleteAmount;i++)
        {
            athleteIDs[i] = GeneratePlayerID();
        }
        StartMatch(matchType);
    }

    void Update ()
    {
        matchTimer++;
        if (matchTimer > matchDuration*120)
        {
            Debug.Log("Draw!");
            Destroy(athlete1);
            Destroy(athlete2);
            StartMatch(0);
            matchTimer = 0;
        }
    }

    public string GeneratePlayerID()
    {
        float baseSpeed = (Random.value * 10) + 5;
        int abilityType = (int)Mathf.Floor(Random.value * 5f);
        float baseMass = Random.value * 2.5f;
        float abilityPower = Random.value + 0.5f;
        float abilityCooldown = (Random.value * 3) + 1;
        Color mainColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        Color frontColor = new Color((1 - mainColor.r) + ((Random.value * 0.1f) - 0.2f), (1 - mainColor.g) + ((Random.value * 0.1f) - 0.2f), (1 - mainColor.b) + ((Random.value * 0.1f) - 0.2f), 1.0f);
        string id = baseSpeed + " " + abilityType + " " + baseMass + " " + abilityPower + " " + abilityCooldown + " " + mainColor.r + " " + mainColor.g + " " + mainColor.b + " " + frontColor.r + " " + frontColor.g + " " + frontColor.b;
        return id;
    }

    public GameObject InitialiseAthleteFromID(string id,Vector3 spawnPosition)
    {
        string[] splitID = id.Split(" "[0]);
        GameObject champ = (GameObject)Instantiate(Resources.Load("Athlete"));
        champ.transform.position = spawnPosition;
        champ.GetComponent<AthleteMovement>().baseSpeed = float.Parse(splitID[0]);
        champ.GetComponent<AthleteMovement>().abilityType = int.Parse(splitID[1]);
        champ.GetComponent<AthleteMovement>().baseMass = float.Parse(splitID[2]);
        champ.GetComponent<AthleteMovement>().abilityPower = float.Parse(splitID[3]);
        champ.GetComponent<AthleteMovement>().abilityCooldown = float.Parse(splitID[4]);
        champ.GetComponent<SpriteRenderer>().color = new Color(float.Parse(splitID[5]), float.Parse(splitID[6]), float.Parse(splitID[7]), 1.0f);
        champ.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(float.Parse(splitID[8]), float.Parse(splitID[9]), float.Parse(splitID[10]), 1.0f);
        champ.GetComponent<Rigidbody2D>().mass = champ.GetComponent<AthleteMovement>().baseMass;
        champ.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
        champ.name = "Athlete: Ability: " + champ.GetComponent<AthleteMovement>().abilityType;
        return champ ;
    }

    public void StartMatch(int type)
    {
        string athleteID1 = athleteIDs[(int)Mathf.Floor(Random.value * athleteAmount)];
        string athleteID2;
        do
        {
            athleteID2 = athleteIDs[(int)Mathf.Floor(Random.value * athleteAmount)];
        } while (athleteID2 == athleteID1);
        athlete1 = InitialiseAthleteFromID(athleteID1, new Vector3(2.2f, 2.5f, 0));
        athlete2 = InitialiseAthleteFromID(athleteID2, new Vector3(0, -2.8f, 0));
        athlete1.GetComponent<AthleteMovement>().opponent = athlete2;
        athlete2.GetComponent<AthleteMovement>().opponent = athlete1;
        athlete1.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
        athlete2.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
        /*switch (type)
        {
            case 0:
                GameObject champ = (GameObject)Instantiate(Resources.Load("Athlete"));
                champ.transform.position = new Vector3(2.2f, 2.5f, 0);
                champ.GetComponent<AthleteMovement>().baseSpeed = (Random.value * 10) + 5;
                champ.GetComponent<AthleteMovement>().abilityType = (int) Mathf.Floor(Random.value*5f);
                champ.GetComponent<AthleteMovement>().baseMass = Random.value * 2.5f;
                champ.GetComponent<AthleteMovement>().abilityPower = Random.value+0.5f;
                champ.GetComponent<Rigidbody2D>().mass = champ.GetComponent<AthleteMovement>().baseMass;
                champ.GetComponent<AthleteMovement>().abilityCooldown = (Random.value * 3)+1;
                champ.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
                champ.name = "Athlete:" + champ.GetComponent<AthleteMovement>().abilityType;

                GameObject champ2 = (GameObject)Instantiate(Resources.Load("Athlete"));
                champ2.transform.position = new Vector3(0, -2.8f, 0);
                champ2.GetComponent<AthleteMovement>().baseSpeed = (Random.value * 10) + 5;
                champ2.GetComponent<AthleteMovement>().abilityType = (int)Mathf.Floor(Random.value * 5f);
                champ2.GetComponent<AthleteMovement>().baseMass = Random.value * 2.5f;
                champ2.GetComponent<AthleteMovement>().abilityPower = Random.value + 0.5f;
                champ2.GetComponent<Rigidbody2D>().mass = champ2.GetComponent<AthleteMovement>().baseMass;
                champ2.GetComponent<AthleteMovement>().abilityCooldown = (Random.value * 3) + 1;
                champ2.GetComponent<AthleteMovement>().goal = GameObject.Find("Goal");
                champ2.name = "Athlete: " + champ2.GetComponent<AthleteMovement>().abilityType;

                champ2.GetComponent<AthleteMovement>().opponent = champ;
                champ.GetComponent<AthleteMovement>().opponent = champ2;
                break;
                */
    }
}
