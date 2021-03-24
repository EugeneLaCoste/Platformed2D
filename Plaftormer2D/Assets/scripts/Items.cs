using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	public int[] items = new int[] { 0, 5, 10, 15, 20, 25 };
	public bool[] hasItems = new bool[] { true, true, false, false, false, false };

	private int currItem = 0;
	public int defence = 0;

	public GameObject armorObject;
	public Sprite[] sprites;

	public void Equip(int index)
	{
		if (hasItems[index])
		{
			currItem = index;
			defence = items[currItem];
			armorObject.GetComponent<SpriteRenderer>().sprite = sprites[currItem];
		}
	}

	public void AddItem(int index)
	{
		hasItems[index] = true;
	}
}
