using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Vector2 dragOffset = new Vector2(0f, 0f);
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;
	GameObject placeholder = null;

	public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log("OnBeginDrag");

		placeholder = new GameObject (); //placeholder for card
		placeholder.transform.SetParent(this.transform.parent); 
		LayoutElement le = placeholder.AddComponent<LayoutElement>(); //set placeholder and make copy cont on bottom
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex());

		parentToReturnTo = this.transform.parent; //Set Parent
		placeholderParent = parentToReturnTo;

		this.transform.SetParent (this.transform.parent.parent); //Transform up by one parent
		GetComponent<CanvasGroup> ().blocksRaycasts = false; // set casts to false
	
		dragOffset = eventData.position - (Vector2)this.transform.position; //Set Offset position

	}
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log("OnDraggggg");

		this.transform.position = eventData.position - dragOffset; //drag based on diffrence of offset and position

		if (placeholder.transform.parent != placeholderParent) {
			placeholder.transform.SetParent (placeholderParent);
		}

		int newSiblingIndex = placeholderParent.childCount; //keep track of index

		for (int i = 0; i < placeholderParent.childCount; i++) {
			if ((this.transform.position.x) < placeholderParent.GetChild (i).position.x) { 
				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex) {
					newSiblingIndex--;
				}

				break;
			}
		}

		placeholder.transform.SetSiblingIndex (newSiblingIndex);
	}
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log("OnEndDrag");

		this.transform.SetParent(parentToReturnTo); // return to orginal parent
		this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup> ().blocksRaycasts = true; // set casts to true
		Destroy(placeholder);
	}
}
