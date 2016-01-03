using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


    public static bool pausa;
    public GameObject CharacterMovementScript;

	// Use this for initialization
	void Start () {
        GameManager.pausado = pausa;
	}
	
	// Update is called once per frame
	void Update () {
        
       // pausa = !GameManager.pausado;//deixa o valor de pausado diferente do valor atual
        
        if (pausa) {
            Time.timeScale = 0;
        } else if (!pausa) {
            Time.timeScale = 1;
        }
       
        GameManager.pausado = pausa;
    }

    public void setPause() {
        pausa = !GameManager.pausado;//deixa o valor de pausado diferente do valor atual

        if (pausa)
        {
            GameManager.desabilitar_controle = true;
            Time.timeScale = 0;
        }
        else if (!pausa)
        {
            GameManager.jogador_esta_vivo = true;
            GameManager.desabilitar_controle = false;
            Time.timeScale = 1;
        }

        GameManager.pausado = pausa;
    }
}
