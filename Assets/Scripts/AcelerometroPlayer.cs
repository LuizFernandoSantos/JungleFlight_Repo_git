using UnityEngine;
using System.Collections;

public class AcelerometroPlayer : MonoBehaviour {

        //variaveis de TouchPhase
        public float minSwipeDistY = 0.5f;

        public float minSwipeDistX;

        public Vector2 startPos;


        //public Vector2 startPos;
        public Vector2 direction;
        public bool directionChosen;

        //variaveis acelerometro
        public float moveX = Input.acceleration.x;
		public float moveY = Input.acceleration.y;
		public float moveZ = Input.acceleration.z;
		public int zeroZFlag;

        //variavaeis de status
        public float velocidade = 0;
        public float pulo = 5;
        public float lane;
        public float posicao_base=103.39f;
        public float posicao_max = 103.43f;
        public bool apertou = false;

    void Update () {

        
   

            moveX =  0;
            moveY = 0;
            moveZ = 0; //~0.036 when flat, moveZ stays positive
            transform.Translate (0, 0, 0);       // no movement when flat

            transform.Translate (0, Input.acceleration.y, 0);       
            zeroZFlag = 1;  
            


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

        if (Input.GetButtonDown("Jump") && transform.position.y == posicao_base)
        {//||Input.GetMouseButtonDown(0)) && transform.position.y >= 103.39f) {
            apertou = true;
            newPosition.y += pulo;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newPosition.y = posicao_base;
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
            newPosition.y = posicao_base;
        }
        else if (apertou)
        {

            //(transform.position.x, pulo, transform.position.z);
            if (transform.position.y == posicao_base)
            {
                apertou = false;
            }

        }
        //newPosition.z += Time.deltaTime*velocidade;

        //transform.Rotate (Vector3.up, 0.0f);

        //if(lane == 0){
        //	newPosition.x = 0;
        //}

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

                            newPosition.y += pulo;
                        }
                        //Jump ();

                        else if (swipeValue < 0)//down swipe
                        {

                            { newPosition.y = posicao_base; }
                        }
                        //Shrink ();

                    }



                    if (swipeDistHorizontal > minSwipeDistX && swipeDistVertical < swipeDistHorizontal)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0.1f)//right swipe
                        {   //if(lane < 1){
                            lane++;
                            //}
                            //MoveRight ();
                        }
                        else if (swipeValue < 0.1f)//left swipe
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

    }
    }
