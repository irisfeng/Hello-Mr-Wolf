using UnityEngine;
using System.Collections;

public class JumpAnimationController : MonoBehaviour {

	Animator anim;
	public GameObject thePlayer;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerBounce bounceScript = thePlayer.GetComponent<PlayerBounce> ();
		if (bounceScript.justJump == true) {
			anim.SetBool ("Jump", true);
		} else {
			anim.SetBool ("Jump", false);
		}
		if (Input.GetButtonDown ("right")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 90, 0);
		}
		if (Input.GetButtonDown ("left")) {
			gameObject.transform.rotation = Quaternion.Euler (0, -90, 0);
		}
		if (Input.GetButtonDown ("up")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		if (Input.GetButtonDown ("down")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "groundblock") {
			other.gameObject.transform.position = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.2f, other.gameObject.transform.position.z);
		}
	}


	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "groundblock") {
			other.gameObject.transform.position = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.2f, other.gameObject.transform.position.z);
		}
	}
}
