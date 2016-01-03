using UnityEngine;
using System.Collections;

public class Destroy_Obstaculo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider outro) {

        if (outro.tag == "Player") {
            
            Destroy(gameObject);
        }
    }
}
