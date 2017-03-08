using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public Dictionary<string,int> slots = new Dictionary<string,int> ();
	public int level = 1;
	public string gender = "male";
	public int totalBonus = 1;
	public int smallItems = 0;
	public int totalItems = 0;

	public Dictionary<string,int> slotsMax = new Dictionary<string,int> ();


	void Start() {

		slots.Add ("armor", 0);
		slots.Add ("hand", 0);
		slots.Add ("foot gear", 0);
		slots.Add ("head gear", 0);
		slots.Add ("big", 0);
		slots.Add ("small", 0);

		slotsMax.Add ("armor", 1);
		slotsMax.Add ("hand", 2);
		slotsMax.Add ("foot gear", 1);
		slotsMax.Add ("head gear", 1);
		slotsMax.Add ("big", 1);
		slotsMax.Add ("small", 99);


	}

	public bool addBonus(Treasure t) {
		if (this.isValidTreasure (t)) {
			foreach (string key in slots.Keys) {
				slots [key] = slots [key] + t.slots [key]; //increase type of items
			}
			slots [t.itemSize]++; //increase item count big or small
			totalBonus += t.bonus;
			return true;
		} 
		return false;
	}

	public void removeBonus(Treasure t) {
		foreach (string key in slots.Keys) {
			slots [key] = slots [key] - t.slots [key];
		}
		slots [t.itemSize]--;
		totalBonus -= t.bonus;
	}

	public void levelUp () {
		this.level++;
		this.totalBonus += 1;
	}

	public void levelDown() {
		if (this.level != 1) {
			this.level--;
			this.totalBonus -= 1;
		}
	}

	public bool isValidTreasure(Treasure t) {
		foreach (string key in slots.Keys) {
			if ((slots [key] + t.slots [key]) > this.slotsMax[key])
				return false;
		}
		return true;
	}

}
