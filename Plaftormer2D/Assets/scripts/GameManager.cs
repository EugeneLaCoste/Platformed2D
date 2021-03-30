using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject PlayerObj;
	public GameObject gameOver;
	public GameObject wavePassed;
	public Animator wave;
	public GameObject[] enemies;
	public GameObject enemyPrefab;
	public GameObject timer;
	public GameObject pauseMenu;
	public bool levelOne = false;
	public bool levelTwo = false;
	private bool pause = false;

	void Start () {
		wave = wavePassed.GetComponent<Animator>();
	}
	
	void Update () {
		if (PlayerObj.GetComponent<Player>().death == true) {
			gameOver.SetActive(true);
		}
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (enemies.Length == 0) {
			wavePassed.SetActive(true);
			if(SceneManager.GetActiveScene().buildIndex == 1) {
				levelOne = true;
			} else if (SceneManager.GetActiveScene().buildIndex == 2) {
				levelOne = true;
				levelTwo = true;
			}
			
			StartCoroutine(loader());
		}

        if (Input.GetKeyDown(KeyCode.Escape)) {
			if (pause == false) {
				OnPause();
			} else {
				OnResume();
			}
		}
	}
	IEnumerator loader() {
		yield return new WaitForSeconds(3f);
		GetComponent<SaverBase>().Save();
		if (SceneManager.GetActiveScene().buildIndex != 3) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		} else { 
			SceneManager.LoadScene("StartMenu");
		}
		
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		OnResume();
	}

	public void OnResume() {
		Time.timeScale = 1;
		pause = false;
		pauseMenu.SetActive(false);
	}

	public void OnPause() {
    	Time.timeScale = 0;
		pause = true;
    	pauseMenu.SetActive(true);
	}

	public void OnMenu() {
		SceneManager.LoadScene("StartMenu");
		OnResume();
	}
}
