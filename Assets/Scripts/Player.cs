using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	Dictionary<string,int> slots = new Dictionary<string,int> ();
	int level = 1;

	void Start() {

		slots.Add ("armor", 0);
		slots.Add ("right hand", 0);
		slots.Add ("left hand", 0);
		slots.Add ("foot gear", 0);
		slots.Add ("head gear", 0);
		slots.Add ("small items", 0);
		slots.Add ("big items", 0);
		slots.Add ("total items", 0);


	}
	

}
