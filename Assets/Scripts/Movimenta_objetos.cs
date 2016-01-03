using UnityEngine;
using System.Collections;

public class Movimenta_objetos : MonoBehaviour {

	Vector3 newPosition;


	public GameObject chao_vazio;
	public GameObject chao_obstaculo;
	public GameObject chao_obstaculo_centro;
	public GameObject chao_obstaculo_direito;
	public GameObject chao_obstaculo_esquerdo;
	public GameObject chao_obstaculo_alto;
	public GameObject cameraTroca;

	public int sorteio;
	public int sorteioAnterior=GameManager.sorteioAnterior;
	public static int sorteio_troca_camera;
	public static bool troca_camera;
	public float velocidade;// = GameManager.velocidade;
	public int contador = 0;
	public float distancia_Nascimento=85;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		if(Camera_Alterna.camera_Atual=="3d"){
			GameManager.velocidade=60;
			velocidade = GameManager.velocidade;
		}
		if(Camera_Alterna.camera_Atual=="2d"){
			GameManager.velocidade=25;
			velocidade = GameManager.velocidade;
		}
		
		Vector3 newPosition = transform.position;
		newPosition.z += (Time.deltaTime*velocidade)*(-1);
		transform.position = newPosition;


	}

	void OnTriggerEnter(Collider outro){
		sorteio = Random.Range (0, 5);
		sorteio_troca_camera = Random.Range (0, 10);
		if (sorteio_troca_camera < 7) {
			troca_camera = true;
		} else {
			//troca_camera = true;
		}
		

		if (outro.tag == "cria_objeto") {
			sorteio = Random.Range(0,6);
			if (GameManager.sorteioAnterior==0&&sorteio==0) {
					sorteio = Random.Range(1,6);
					
			}
			if(contador==0){
				
				if (sorteio == 0) {
					Instantiate (chao_vazio, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=0;
					GameManager.contador_de_vazios++;
				}
				if (sorteio == 1) {
					Instantiate (chao_obstaculo, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					//chao_obstaculo
					GameManager.sorteioAnterior=1;
				}
				if (sorteio == 2) {
					Instantiate (chao_obstaculo_centro, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=2;
				}
				if (sorteio == 3) {
					Instantiate (chao_obstaculo_direito, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=3;
				}
				if (sorteio == 4) {
					Instantiate (chao_obstaculo_esquerdo, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=4;
				}
				if (sorteio == 5) {
					Instantiate (chao_obstaculo_alto, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=5;
				}if (sorteio == 6) {
					Instantiate (chao_vazio, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
					GameManager.sorteioAnterior=0;
				}contador++;	
				
			}else if (contador>0){
				sorteioAnterior=GameManager.sorteioAnterior;
			}

			
						

		} 
		if(GameManager.contador_de_vazios==3){
			Instantiate (cameraTroca, new Vector3 (transform.position.x, transform.position.y, transform.position.z + distancia_Nascimento), Quaternion.identity);
			GameManager.contador_de_vazios=0;
		}
		if (outro.tag == "destroi_objeto"){
			Destroy(gameObject);
		}
	}
}
