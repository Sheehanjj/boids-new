using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	[Header("Set Dynamically")]
	public Rigidbody	rigid;

	void Awake(){
		rigid = GetComponent<Rigidbody> ();

		// Set a random initial position
		pos = Random.insideUnitSphere * Spawner.S.spawnRadius;

		// Set a random initial velocity
		Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
		rigid.velocity = vel;

		LookAhead ();

		// Give each Boid a Random Color
		Color randColor = Color.black;
		while (randColor.r + randColor.g + randColor.b < 1.0f) {
			randColor = new Color (Random.value, Random.value, Random.value);
		}
		Renderer[] rends = gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in rends) {
			r.material.color = randColor;
		}
		TrailRenderer tRend = GetComponent<TrailRenderer> ();
		tRend.material.SetColor ("_TintColor", randColor);
	}

	void LookAhead(){
		// orients the Boid to look in the direction that it is flying
		transform.LookAt (pos + rigid.velocity);
	}

	void FixedUpdate(){
		Vector3 vel = rigid.velocity;
		Spawner spn = Spawner.S;

		// Attract the Boid to the Attractor
		Vector3 delta = Attractor.POS - pos;

		// Is the Boid already moving towards the Attractor
		bool attracted = (delta.magnitude > spn.attractPushDist);
		Vector3 velAttract = delta.normalized * spn.velocity;

		float fdt = Time.fixedDeltaTime;

		if (attracted) {
			vel = Vector3.Lerp (vel, velAttract, spn.attractPull * fdt);
		} else {
			vel = Vector3.Lerp (vel, -velAttract, spn.attractPush * fdt);
		}

		vel = vel.normalized * spn.velocity;
		rigid.velocity = vel;

		LookAhead ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 pos {
		get { return transform.position; }
		set { transform.position = value; }
	}
}
