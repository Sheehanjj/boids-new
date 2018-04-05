using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public Vector3 pos {
		get { return transform.position; }
		set { transform.position = value; }
	}

	void FixedUpdate(){
		Vector3 vel = rigid.velocity;
		Spawner spn = Spawner.S;

		Vector3 delta = Atrractor.POS - pos;
		bool attracted = (delta.magnitude > spn.attractPushDist);
		Vector3 velAttract = delta.normalized * spn.velocity;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
