using UnityEngine;
using System.Collections;

public class caamera_Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.y = 0.0f;
	}
}
