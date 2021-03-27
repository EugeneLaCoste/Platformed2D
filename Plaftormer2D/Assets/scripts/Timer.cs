using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public GameObject gameOver;
	public float counter;
	
	void Start () {
		StartCoroutine(reloadTimer(1));
	}
	
	IEnumerator reloadTimer(float reloadTimeInSeconds) {
		counter = 92;
		
		while (counter > reloadTimeInSeconds) {
			counter -= Time.deltaTime;
			if (counter < 10) {
				timerText.text = counter.ToString().Substring(0,1);
			} else if (counter < 100){
				timerText.text = counter.ToString().Substring(0,2);
			} else {
				timerText.text = counter.ToString().Substring(0,3);
			}
			if (counter < 1) {
				gameOver.SetActive(true);
			}
			yield return null;
		}
	}
	
}
