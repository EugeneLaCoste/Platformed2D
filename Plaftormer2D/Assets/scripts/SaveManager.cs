using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveManager : MonoBehaviour {

	public UnityEvent save;
	public UnityEvent load;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F6)) {
			save.Invoke();
		}

		if (Input.GetKeyDown(KeyCode.F7)) {
			load.Invoke();
		}
	}
}
