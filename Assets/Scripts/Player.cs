using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Dictionary<string,int> slots = new Dictionary<string,int> ();
	public int level = 1;
	public string gender = "male";
	public int totalBonus = 1;
	public int smallItems = 0;
	public int totalItems = 0;
	public Text textLevel;
	public Text textBonus;



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
			foreach (string key in t.slots.Keys) {
				this.slots [key] = this.slots [key] + t.slots [key]; //increase type of items
			}
			this.slots [t.itemSize]++; //increase item count big or small
			totalBonus += t.bonus;
			//Debug.Log (textName.name);
			this.textBonus.text = "Total Bonus " + this.totalBonus.ToString();
			return true;
		
		} 
		return false;
	}

	public void removeBonus(Treasure t) {
		foreach (string key in t.slots.Keys) {
			this.slots [key] = this.slots [key] - t.slots [key];
		}
		this.slots [t.itemSize]--;
		this.totalBonus -= t.bonus;
		this.textBonus.text = "Total Bonus " + this.totalBonus.ToString();
	}

	public void levelUp () {
		this.level++;
		this.totalBonus += 1;
		this.textLevel.text = "Level " + this.level.ToString();

	}

	public void levelDown() {
		if (this.level != 1) {
			this.level--;
			this.totalBonus -= 1;
			this.textLevel.text = "Level " + this.level.ToString();
		}
	}

	public bool isValidTreasure(Treasure t) {
		foreach (string key in t.slots.Keys) {
			if ((this.slots [key] + t.slots [key]) > this.slotsMax[key])
				return false;
		}
		return true;
	}

}
