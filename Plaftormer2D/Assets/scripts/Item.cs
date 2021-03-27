using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public GameObject player;
	int value;

	void Start() {
		if (gameObject.transform.tag == "Apple") {
			value = 1;
		} else if (gameObject.transform.tag == "Beer") {
			value = 5;
		} else if (gameObject.transform.tag == "Brownie") {
			value = 3;
		}
	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.transform.tag == "Player") 
		{
			gameObject.SetActive(false);
			player.GetComponent<Player>().Heal(value);
		}
	}
}
