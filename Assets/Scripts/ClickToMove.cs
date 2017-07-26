/* 
 * Esse Script movimenta o GameObject quando você clica ou
 * mantém o botão esquerdo do mouse apertado.
 * 
 * Para usá-lo, adicione esse script ao gameObject que você quer mover
 * seja o Player ou outro
 * 
 * Autor: Vinicius Rezendrix - Brasil
 * Data: 11/08/2012
 * 
 * This script moves the GameObeject when you
 * click or click and hold the LeftMouseButton
 * 
 * Simply attach it to the gameObject you wanna move (player or not)
 * 
 * Autor: Vinicius Rezendrix - Brazil
 * Data: 11/08/2012 
 *
 */

using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	private Transform myTransform;				// this transform
	public Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
	public GameObject destinationGoal;
	public GameObject _destinationGoal;
	public float moveSpeed;						// The Speed the character will move

	private bool goalcreated;

	[SerializeField]
	private Animator animator; //animator for unit


	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
		goalcreated = false;

	}

	void Update () {


		//Destroys Extra Goals
		GameObject[] destroyGoal;
		destroyGoal = GameObject.FindGameObjectsWithTag ("Goal");
		for (int i = 1; i < destroyGoal.Length; i++) {
			Destroy (destroyGoal [i].gameObject);
		}
		//

		Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D> ().velocity;

		//sets animator for direction


		if (destinationPosition.x < myTransform.position.x) {
			animator.SetInteger ("DirectionX", -1);
		} else if (destinationPosition.x > myTransform.position.x) {
			animator.SetInteger ("DirectionX", 1);
		} 
			
		if (destinationPosition.y < myTransform.position.y) {
			animator.SetInteger ("DirectionY", -1);
		} else if (destinationPosition.y > myTransform.position.y) {
			animator.SetInteger ("DirectionY", 1);
		}
		if (moveSpeed == 0) {
			animator.SetInteger ("DirectionY", 0);
			animator.SetInteger ("DirectionX", 0);
		}

		// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance (destinationPosition, myTransform.position);
					
		if (destinationDistance < .5f) {		// To prevent shakin behavior when near destination
			moveSpeed = 0;
			Destroy (_destinationGoal);
			goalcreated = false;
		} else if (destinationDistance > .5f) {			// To Reset Speed to default
			moveSpeed = 10;
		}


		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown (1) && GUIUtility.hotControl == 0) {

			Vector3 targetPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			destinationPosition = new Vector3 (targetPoint.x, targetPoint.y, transform.position.z);

			if (goalcreated) {
				_destinationGoal.transform.position = destinationPosition;
			}

			if (!goalcreated) {
				_destinationGoal = Instantiate (destinationGoal, destinationPosition, Quaternion.identity);
				goalcreated = true; 
			}

		}

		// Moves the player if the mouse button is hold down
		else if (Input.GetMouseButton (1) && GUIUtility.hotControl == 0) {

			Vector3 targetPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			destinationPosition = new Vector3 (targetPoint.x, targetPoint.y, transform.position.z);

			if (goalcreated) {
				_destinationGoal.transform.position = destinationPosition;
			}

			if (!goalcreated) {
				_destinationGoal = Instantiate (destinationGoal, destinationPosition, Quaternion.identity);
				goalcreated = true; 
			}

		}

		////////////////////////////////////////////////////////
		/// Changing Animator to Weapon Stance On Combat Mode///
		/// ////////////////////////////////////////////////////

		Animator thisUnitAnimator = this.gameObject.GetComponent<Animator> ();

		if (GameManager.CombatMode == true) {

			thisUnitAnimator.runtimeAnimatorController = Resources.Load ("RifleAnimator") as RuntimeAnimatorController;
		} 
		if (!GameManager.CombatMode == false) {

			thisUnitAnimator.runtimeAnimatorController = Resources.Load ("PlayerAnimator") as RuntimeAnimatorController;
		}


		// To prevent code from running if not needed
		if (destinationDistance > .5f) {	

			//Moves Character
			//myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);

		}
	}
}