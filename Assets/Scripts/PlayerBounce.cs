using UnityEngine;
using System.Collections;

public class PlayerBounce : MonoBehaviour {

	float lerpTime;
	float currentLerpTime;
	float percent = 1f;

	Vector3 startPos, endPos;

	bool firstInput;
	public bool justJump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("up") || Input.GetButtonDown ("down") || Input.GetButtonDown ("left") || Input.GetButtonDown ("right")) {
			if (percent == 1) {
				lerpTime = 1;
				currentLerpTime = 0;
				firstInput = true;
				justJump = true;
			}
		}

		startPos = gameObject.transform.position;

		if (Input.GetButtonDown ("right") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		if (Input.GetButtonDown ("left") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		if (Input.GetButtonDown ("up") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 4);
		}
		if (Input.GetButtonDown ("down") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
		}
		if (firstInput == true) {
			currentLerpTime += Time.deltaTime * 7f;
			percent = currentLerpTime / lerpTime;
			gameObject.transform.position = Vector3.Lerp (startPos, endPos, percent);
		}
		if (percent > 0.8f) {
			percent = 1f;
		}
		if (Mathf.Round (percent) == 1) {
			justJump = false;
		}
	
	}
}
