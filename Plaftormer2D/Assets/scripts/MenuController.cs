using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuController : MonoBehaviour {

	public GameObject levelTwo;
	public GameObject levelThree;
	public GameObject lockTwo;
	public GameObject lockThree;
	public bool levelFirst;
	public bool levelSecond;

	public string data;
	// Use this for initialization
	void Start () {
		data = File.ReadAllText("D:/save.txt");
		if (data != null) {
			JsonUtility.FromJsonOverwrite(data, this);
		}
		
		if(levelFirst == true) {
			levelTwo.GetComponent<Button>().enabled = true;
			lockTwo.SetActive(false);	
		}

		if (levelSecond == true) {
			levelThree.GetComponent<Button>().enabled = true;
			lockThree.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnExit() {
		Application.Quit();
	}

	public void LevelChooser(int levelID) {
		SceneManager.LoadScene(levelID);
	}


}
