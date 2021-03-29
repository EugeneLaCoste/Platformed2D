using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	
	private Rigidbody2D rg;
	public GameObject player;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > transform.position.x - 2 && player.transform.position.x < transform.position.x + 2) {
			rg.constraints = RigidbodyConstraints2D.None;
			Debug.Log("ROCK");
		}
		
	}
	void OnCollisionEnter2D(Collision2D obj) {
		if (Mathf.Abs(rg.velocity.y) > 10 && obj.transform.tag == "Player" ) {
        	player.GetComponent<Player>().TakeDamage(2);
        }
    }
}
