using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	static public Spawner		S;
	static public List<Boid>	boids;

	[Header("Set in Inspector: Spawning")]
	public GameObject	boidPrefab;
	public Transform	boidAnchor;
	public int			numBoids = 100;
	public float		spawnRadius = 100f;
	public float		spawnDelay = 0.1f;

	void Awake () {
		S = this;
		boids = new List<Boid>();
		InstantiateBoid();
	}

	public void InstantiateBoid(){
		GameObject go = Instantiate (boidPrefab);
		Boid b = go.GetComponent<Boid> ();
		b.transform.SetParent (boidAnchor);
		boids.Add (b);
		if (boids.Count < numBoids){
			Invoke ("InstantiateBoid", spawnDelay);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
