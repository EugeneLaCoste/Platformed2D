using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	
	private Rigidbody2D rg;
	public Transform player;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.x > transform.position.x - 2 && player.position.x < transform.position.x + 2) {
			rg.constraints = RigidbodyConstraints2D.None;
			Debug.Log("ROCK");
		}
		
	}
}
