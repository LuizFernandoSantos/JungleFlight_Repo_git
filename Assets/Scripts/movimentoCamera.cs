using UnityEngine;
using System.Collections;

public class movimentoCamera : MonoBehaviour {



	public int velocidadeCamera = 25;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPosition = transform.position;
		newPosition.z += (Time.deltaTime * velocidadeCamera)*(-1);
		transform.position = newPosition;
		if (GameManager.contador_de_vazios == 3) {
			
		}
	}
	void OnTriggerEnter(Collider outro){
		if(outro.tag=="destroi_objeto"){
			Destroy(this.gameObject);
		}
	}
}
