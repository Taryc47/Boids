using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
	
   /* This ia a Singleton of the BoidSpawner. There is only one instance
		of BoidSpawner, so we can store it in a static variable named S.*/
	static public Spawner		S;
	static public List<Boid>	boids;
	
	// These fields allow you to adjust the spawning behaviour of the Boids.
	[Header("Set in Inspector: Spawning")]
	public GameObject			boidPrefab;
	public Transform			boidAnchor;
	public int					numBoids = 100;
	public float				spawnRadius = 100f;
	public float				spawnDelay = 0.1f;
	
	// These fields allow you to adjust the flocking behaviour of the Boids.
	[Header("Set in Inspector: Boids")]
	public float				velocity = 30f;
	public float				neighborDist = 30f;
	public float				collDist = 4f;
	public float				velMatching = 0.25f;
	public float				flockCentering = 0.2f;
	public float				collAvoid = 2f;
	public float				attractPull = 2f;
	public float				attractPush = 2f;
	public float				attractPushDist = 5f;
	
	void Awake(){
		// Set the Singleton S to be this instance of BoidSpawner
		S = this;
		// Start instantiation of the Boids
		boids = new List<Boid>();
		InstantiateBoid();
	}
	
	public void InstantiateBoid(){
		GameObject go = Instantiate(boidPrefab);
		Boid b = go.GetComponent<Boid>();
		b.transform.SetParent(boidAnchor);
		boids.Add( b );
		if(boids.Count < numBoids){
			Invoke("InstantiateBoid", spawnDelay);
		}
	}
}
