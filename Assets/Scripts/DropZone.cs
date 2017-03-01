using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log ("OnPointerEnter");
	}

	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " was dropped to " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null) {
			d.parentToReturnTo = this.transform; // set draggable objects parent to this instance
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log ("OnPointerExit");
	}
}
