using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaverBase : MonoBehaviour {

	public bool levelFirst;
	public bool levelSecond;

	[Multiline(10)]
	public string data;

	public void CollectInfo() {
		levelFirst = GetComponent<GameManager>().levelOne;
		levelSecond = GetComponent<GameManager>().levelTwo;
	}

	public void SetInfo() {
		GetComponent<GameManager>().levelOne = levelFirst;
		GetComponent<GameManager>().levelTwo = levelSecond;
	}

	public void Save() {
		CollectInfo();
		data = JsonUtility.ToJson(this, true);
		File.WriteAllText("D:/save.txt", data)	;
	}

	public void Load() {
		data = File.ReadAllText("D:/save.txt");
		JsonUtility.FromJsonOverwrite(data, this);
		SetInfo();	
	}
}
