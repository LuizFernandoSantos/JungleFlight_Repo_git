using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject Painal_de_pausa;
    

    public bool pausado;

	// Use this for initialization
	void Start () {
        pausado = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.pausado) {
            JogoPausado(true);
        } else {
            JogoPausado(false);
        }
        if (Input.GetButtonDown("0")) {
            AlternaPause();
        }
	}

    void JogoPausado(bool estado) {
        if (estado)
        {
            GameManager.desabilitar_controle = true;
            Painal_de_pausa.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
            GameManager.jogador_esta_vivo = true;
            GameManager.desabilitar_controle = false;
            Painal_de_pausa.SetActive(false);
        }
        Painal_de_pausa.SetActive(estado);
    }

    public void AlternaPause() {
        if (pausado)
        {
            pausado = false;
        }
        else {
            pausado = true;
        }

    }

}
