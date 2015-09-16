using UnityEngine;
using System.Collections;

public class RingCheck : MonoBehaviour {

    public float ringDamage;

    void onTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<AthleteMovement>().currentHealth -= ringDamage;
    }
}
