using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public Dictionary<string,int> slots = new Dictionary<string,int> ();
	public int level = 1;
	public string gender = "male";
	public int totalBonus = 1;
	public int smallItems = 0;
	public int bigItems = 0;
	public int totalItems = 0;

	void Start() {

		slots.Add ("armor", 0);
		slots.Add ("right hand", 0);
		slots.Add ("left hand", 0);
		slots.Add ("foot gear", 0);
		slots.Add ("head gear", 0);

	}

	public void addBonus(Treasure t) {
		foreach (string key in slots.Keys) {
			slots [key] = slots [key] + t.slots [key];
		}
	}

	public void removeBonus(Treasure t) {

	}

}
