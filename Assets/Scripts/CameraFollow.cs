using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject animalPlayer;
	Vector3 shouldPos;
	
	// Update is called once per frame
	void Update () {
		shouldPos = Vector3.Lerp (gameObject.transform.position, animalPlayer.transform.position, Time.deltaTime * 5);
		gameObject.transform.position = new Vector3 (shouldPos.x , 1, shouldPos.z);
	}
}
