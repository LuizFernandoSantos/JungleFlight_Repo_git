using UnityEngine;
using System.Collections;

public class CharacterMovementScript : MonoBehaviour {

	GameManager gameManager;
   
    public int count_pause;

    Vector3 newPosition;
	
	public bool apertou=false;
    public bool desabilitar_controle;


    public float velocidade = 0;
	public float pulo=0;
	public float lane;
	public float posicao_base;
	public float posicao_max;

	//variaveis de TouchPhase
	public float minSwipeDistY=0.5f;
	
	public float minSwipeDistX;
	
	public Vector2 startPos;


	//public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;
    


    // Use this for initialization
    void Start () {
        
        GameManager.jogador_esta_vivo = true;
        Pause.pausa = false;
        Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update() {
        
        if (GameManager.pausado == false  && GameManager.desabilitar_controle==false)
        {
            Vector3 newPosition = transform.position;
            // Track a single touch as a direction control.
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                // Handle finger movements based on touch phase.
                switch (touch.phase)
                {
                    // Record initial touch position.
                    case TouchPhase.Began:
                        startPos = touch.position;
                        directionChosen = false;
                        break;

                    // Determine direction by comparing the current touch position with the initial one.
                    case TouchPhase.Moved:
                        direction = touch.position - startPos;
                        break;

                    // Report that a direction has been chosen when the finger is lifted.
                    case TouchPhase.Ended:
                        directionChosen = true;
                        break;
                }
            }
            if (directionChosen)
            {
                print(direction);
            }

            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 103.40f)
            {//||Input.GetMouseButtonDown(0)) && transform.position.y >= 103.39f) {
                apertou = true;
                GameManager.pulando = true;
                newPosition.y += pulo;
            }
            // if (Input.GetKeyDown(KeyCode.DownArrow))
            //{

            //}
            if (transform.position.y > 103.4f)
            {
                transform.Translate(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //if(lane > -1){
                lane--;
                //}
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //if(lane < 1){
                lane++;
                //}
            }


            if (apertou == false && transform.position.y < 1)
            {
                GameManager.pulando = false;
                GameManager.correndo = true;
                newPosition.y = 103.40f;
            }
            else if (apertou)
            {

                //(transform.position.x, pulo, transform.position.z);
                if (transform.position.y == posicao_base)
                {
                    apertou = false;
                }

            }
            newPosition.z += Time.deltaTime * velocidade;

            transform.Rotate(Vector3.up, 0.0f);

            if (lane == 0)
            {
                newPosition.x = 0;
            }

            //touch movement
            //#if UNITY_ANDROID

            if (Input.touchCount > 0)

            {

                Touch touch = Input.touches[0];



                switch (touch.phase)

                {

                    case TouchPhase.Began:

                        startPos = touch.position;

                        break;



                    case TouchPhase.Ended:

                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                        if (swipeDistVertical > minSwipeDistY && swipeDistVertical > swipeDistHorizontal)
                        {

                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                            if (swipeValue > 0 && transform.position.y < 103.40f)//up swipe
                            {
                                GameManager.correndo = false;
                                GameManager.pulando = true;
                                newPosition.y += pulo;
                            }
                            //Jump ();

                            else if (swipeValue < 0)//down swipe
                            {
                                if (transform.position.y > 103.4f)
                                {
                                    newPosition.y = newPosition.y -= 0.1f;
                                }
                            }
                            //Shrink ();

                        }



                        if (swipeDistHorizontal > minSwipeDistX && swipeDistVertical < swipeDistHorizontal)

                        {

                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                            if (swipeValue > 0.1f && Camera_Alterna.camera_Atual == "3d")//right swipe
                            {   //if(lane < 1){
                                lane++;
                                //}
                                //MoveRight ();
                            }
                            else if (swipeValue < 0.1f && Camera_Alterna.camera_Atual == "3d")//left swipe
                            {
                                //if(lane > -1){
                                lane--;
                                //}
                            }
                            //MoveLeft ();

                        }
                        break;
                }
            }

            newPosition.x = lane;
            transform.position = newPosition;
            if (Camera_Alterna.camera_Atual == "3d")
            {
                transform.Translate(Input.acceleration.x + Input.acceleration.x + Input.acceleration.x, 0, 0);
            }

        }
        


    }
	void FixedUpdate() {
		transform.eulerAngles = new Vector3 (0,0,0);
              
    }

	void OnTriggerEnter(Collider outro){

		if(Camera_Alterna.camera_Atual=="3d"){
			if (outro.tag == "destroi_objeto" || outro.tag == "obstaculo") {
            	TelaDeMorte();
            
			}
		}if (Camera_Alterna.camera_Atual == "2d"){
			if(outro.tag == "obstaculo_invisivel"||(outro.tag == "destroi_objeto")){ //|| outro.tag == "obstaculo")) {
            TelaDeMorte();
			}
        }
		if (Camera_Alterna.camera_Atual == "3d" && outro.tag == "trocaCamera") {
			GameManager.cameraTroca=true;
		} else if (Camera_Alterna.camera_Atual == "2d" && outro.tag == "trocaCamera") {
			GameManager.cameraTroca=true;
		}
        if (outro.tag == "desabilita_controle") {
            desabilitar_controle = true;
        }
        
	}

    public void TelaDeMorte(){
        lane = 0;
        transform.position = new Vector3(0f, 103.399f, 0f);
        GameManager.jogador_esta_vivo = false;
        desabilitar_controle = true;
        Pause.pausa = true;
        
    }

   


}
