using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Vector2 dragOffset = new Vector2(0f, 0f);
	public Transform parentToReturnTo = null;

	public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log("OnBeginDrag");

		parentToReturnTo = this.transform.parent; //Set Parent
		this.transform.SetParent (this.transform.parent.parent); //Transform up by one parent
		GetComponent<CanvasGroup> ().blocksRaycasts = false; // set casts to false
	
		dragOffset = eventData.position - (Vector2)this.transform.position; //Set Offset position

	}
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log("OnDraggggg");

		this.transform.position = eventData.position - dragOffset; //drag based on diffrence of offset and position
	}
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log("OnEndDrag");

		this.transform.SetParent(parentToReturnTo); // return to orginal parent
		GetComponent<CanvasGroup> ().blocksRaycasts = true; // set casts to true

	}
}
