using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Treasure : MonoBehaviour {

	public int bonus = 0;
	public Dictionary<string,int> slots = new Dictionary<string,int> ();
	public string itemSize = "small";
	public string itemType = "none";

	public int armor = 0;
	public int hand = 0;
	public int footGear = 0;
	public int headGear = 0;
	public int gold = 0;

	void Start() {

		slots.Add ("armor", this.armor);
		slots.Add ("hand", this.hand);
		slots.Add ("foot gear", this.footGear);
		slots.Add ("head gear", this.headGear);

	}
		

}
