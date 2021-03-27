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

	private GameObject enemy;
	private GameObject apple;
	private GameObject beer;
	private GameObject brownie;
	private int waveCount = 1;

	void Start () {
		wave = wavePassed.GetComponent<Animator>();
		apple = GameObject.FindGameObjectWithTag("Apple");
		beer = GameObject.FindGameObjectWithTag("Beer");
		brownie = GameObject.FindGameObjectWithTag("Brownie");
	}
	
	void Update () {
		if (PlayerObj.GetComponent<Player>().death == true) {
			gameOver.SetActive(true);
		}
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (enemies.Length == 0) {
			// waveCount += 1;
			// apple.transform.position = new Vector2(Random.Range(-17, 75), Random.Range(-2, 2));
			// beer.transform.position = new Vector2(Random.Range(-17, 75), Random.Range(-2, 2));
			// brownie.transform.position = new Vector2(Random.Range(-17, 75), Random.Range(-2, 2));
			// apple.SetActive(true);
			// beer.SetActive(true);
			// brownie.SetActive(true);
			wavePassed.SetActive(true);
			// SceneManager.LoadScene("main FIXED");
			// for (int i = 0; i<5; i++) {
			// 	enemy = Instantiate(enemyPrefab) as GameObject;
			// 	enemy.transform.position = new Vector3(Random.Range(-15, 21), -2,0);
			// }
			// for (int j = 0; j < 2; j++) {
			// 	enemy = Instantiate(enemyPrefab) as GameObject;
			// 	enemy.transform.position = new Vector3(Random.Range(53, 93), -2,0);
			// }
			// timer.GetComponent<Timer>().counter += 90;
		}
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
