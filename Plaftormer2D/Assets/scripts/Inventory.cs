using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private Canvas canvas;
	
	void Start () {
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			canvas.enabled = !canvas.enabled;
		}
	}
}
