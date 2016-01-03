using UnityEngine;
using System.Collections;

public class Camera_Alterna : MonoBehaviour {



	public Camera Camera1;
	public Camera Camera2d;

	public static string camera_Atual;

	// Use this for initialization
	void Start () {
		camera_Atual = "3d";
	}
	
	// Update is called once per frame
	void Update () {

		if(GameManager.cameraTroca){
			if(camera_Atual=="2d"){
			//transform.Rotate(0,90,0);// new Vector3(transform.rotation.x,0,transform.rotation.z);
			//	transform.Translate(transform.position.x+-5f,transform.position.y+-1.75f,transform.position.z+9.9f);
				Camera2d.GetComponent<Camera>().enabled = false;	
				Camera1.GetComponent<Camera>().enabled=true;
				camera_Atual = "3d";
				GameManager.cameraTroca=false;
					//transform.
			}else if(camera_Atual=="3d"){//||Movimenta_objetos.troca_camera==true){
				Camera1.GetComponent<Camera>().enabled=false;
				Camera2d.GetComponent<Camera>().enabled = true;	
				camera_Atual = "2d";
				GameManager.cameraTroca=false;
			}
		}	
		//x = 9.9
		//	y =5.01
		//		z =3.5;
	
	
		//rotatex = 7.35347
		//	270.9642y
	
	}
    public void OnTriggerEnter(Collider outro) {
        if (outro.tag == "destroi_objeto") {
            Destroy(gameObject);
        }

    }
}
