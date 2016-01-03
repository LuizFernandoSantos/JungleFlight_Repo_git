using UnityEngine;
using System.Collections;

public class Camera_Movimento : MonoBehaviour {
    public int velocidade = 25;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        newPosition.z += (Time.deltaTime * velocidade) * (-1);
        transform.position = newPosition;
    }
    void OnTriggerEnter(Collider outro) {
        if (outro.tag == "destroi_objeto") {
            Destroy(gameObject);
        }
    }
}
