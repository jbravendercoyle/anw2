using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour {

	GameObject thisUnit;
	public bool SelectThisUnit;

	// Use this for initialization
	void Start () {
		thisUnit = this.gameObject;
		SelectThisUnit = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (SelectThisUnit == true) {
			ClickToMove component = thisUnit.GetComponent<ClickToMove> ();
			component.enabled = true;
			thisUnit.transform.GetChild (0).gameObject.SetActive (true);
		}

		if (SelectThisUnit == false) {
			ClickToMove component = thisUnit.GetComponent<ClickToMove> ();
			component.enabled = false;
			thisUnit.transform.GetChild (0).gameObject.SetActive (false); 
	}
}
}