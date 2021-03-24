using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject PlayerObj;
	public GameObject gameOver;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerObj.GetComponent<Player>().death == true) {
			gameOver.SetActive(true);
		}
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
