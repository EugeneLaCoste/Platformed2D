using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if(!item){
			DragHandeler.item.transform.SetParent(transform);
			DragHandeler.item.transform.position = DragHandeler.item.transform.parent.position;
			Debug.Log(this.gameObject.name);	
		}
	}	
	#endregion
}