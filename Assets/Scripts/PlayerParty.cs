using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

	//First PartyMember
	public GameObject[] PartyMembers;

	// Use this for initialization
	void Start () {
			PartyMembers = GameObject.FindGameObjectsWithTag ("PlayerUnit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
