using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log ("OnPointerEnter");
		if (eventData.pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		Treasure t1 = eventData.pointerDrag.GetComponent<Treasure>();

		if (d != null) {
			if (true) {

			}
			d.placeholderParent = this.transform; // set draggable objects parent to this instance
		}
	}

	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " was dropped to " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		Treasure t1 = eventData.pointerDrag.GetComponent<Treasure>();

		if (d != null) {
			if (true) {

			}
			d.parentToReturnTo = this.transform; // set draggable objects parent to this instance
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log ("OnPointerExit");
		if (eventData.pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		Treasure t1 = eventData.pointerDrag.GetComponent<Treasure>();

		if (d != null && d.placeholderParent == this.transform) {
			if (true) {

			}
			d.placeholderParent = d.parentToReturnTo;
		}
	}
}
