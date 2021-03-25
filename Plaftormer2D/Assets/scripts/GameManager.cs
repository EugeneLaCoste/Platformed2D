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
	private GameObject enemy;
	public GameObject timer;

	void Start () {
		wave = wavePassed.GetComponent<Animator>();
	}
	

	void Update () {
		if (PlayerObj.GetComponent<Player>().death == true) {
			gameOver.SetActive(true);
		}
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		// Debug.Log(enemies.Length);
		if (enemies.Length == 0) {
			// wavePassed.SetActive(true);	
			StartCoroutine(WavePassed());
			wave.SetTrigger("Passed");
			enemy = Instantiate(enemyPrefab) as GameObject;
			for (int i = 0; i<5; i++) {
				enemy.transform.position = new Vector3(Random.Range(-15, 21), -2,0);
			}
			timer.GetComponent<Timer>().counter += 60;
		}
	}

	private IEnumerator WavePassed() {
		wave.SetTrigger("Passed");
		yield return new WaitForSeconds(3f);
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
