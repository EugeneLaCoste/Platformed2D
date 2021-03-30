using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

	public int direction = 1;
	void Start () {

	}
	
	void Update () {
		transform.Rotate(0, 0, 4f * direction); 
	}
}
