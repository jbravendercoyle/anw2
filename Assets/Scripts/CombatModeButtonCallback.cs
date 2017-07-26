using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatModeButtonCallback : MonoBehaviour {

	private Image thisImage;
	public Sprite CombatOnSprite;
	public Sprite CombatOffSprite;

		void Start () {
		thisImage = this.gameObject.GetComponent<Image> ();
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => TurnCombatOn());
		}

	void Update () {


		if (GameManager.CombatMode) {
			thisImage.sprite = CombatOnSprite;
			this.gameObject.GetComponent<Button> ().onClick.RemoveListener (() => TurnCombatOn());
			this.gameObject.GetComponent<Button> ().onClick.AddListener (() => TurnCombatOff ());
		}

		if (!GameManager.CombatMode) {
			thisImage.sprite = CombatOffSprite;
			this.gameObject.GetComponent<Button> ().onClick.RemoveListener (() => TurnCombatOff());
			this.gameObject.GetComponent<Button> ().onClick.AddListener (() => TurnCombatOn());

		}

	}
	private void TurnCombatOn() {

		GameManager.CombatMode = true;
	}

	private void TurnCombatOff() {
		GameManager.CombatMode = false;
	}
}
