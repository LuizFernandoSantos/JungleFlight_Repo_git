using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//variaveis de status do jogo	
	public TextMesh highscores;

	public static bool jogador_esta_vivo;
	public bool primeiro_vez_que_joga;
	public bool esta_online;
    public static bool correndo = true;
    public static bool pulando = false;
    public static bool pausado;
    public static bool desabilitar_controle = false;

    public static int escolheViverAtivo=0;

    public static int recorde;
	public int contador_1;
	public int bonus_atual = 1;
	public int tempo_por_metro	 = 10;
	public static int contador_de_pontos;
	public static int sorteio_anterior=0;
	public static int sorteioAnterior;
	public static int velocidade;
	public static bool cameraTroca=false;

	public static int contador_de_vazios;

	public float timeRemaining = 5;

	// Use this for initialization
	void Start () {
		jogador_esta_vivo = true;
        pausado = false;
		highscores.text = "HIGHER ___ " + PlayerPrefs.GetInt("HighScore");
	}
	
	// Update is called once per frame
	void Update () {

        if (jogador_esta_vivo && pausado == false)
        {
            //Destroy(gameObject);
            desabilitar_controle = false;
            contador_de_pontos += (int)((Time.deltaTime / tempo_por_metro) + bonus_atual);

            GetComponent<TextMesh>().text = "score ___ " + contador_de_pontos;
        }
        else {
            desabilitar_controle = true;
        }
		if(contador_de_pontos>recorde){
			recorde=contador_de_pontos;
		}


		if (contador_de_pontos > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", contador_de_pontos);
		}
		highscores.text ="HIGHER ->> " + PlayerPrefs.GetInt("HighScore");

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
	}
}
