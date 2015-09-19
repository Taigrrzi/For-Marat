using UnityEngine;
using System.Collections;

public class RingCheck : MonoBehaviour {

    public float ringDamage;

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<AthleteMovement>().currentHealth -= ringDamage;
    }
}
