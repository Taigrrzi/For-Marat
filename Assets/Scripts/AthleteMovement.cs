using UnityEngine;
using System.Collections;

public class AthleteMovement : MonoBehaviour {
	public float baseSpeed;
	public float speed;
	public GameObject goal;
	Vector2 direc;
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();

		speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate () {
        direc = (Vector2)(goal.transform.position - transform.position);
        direc.Normalize();
        rbody.AddForce(rbody.mass * direc * speed);
    }
}
