using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


    
    public int count= 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
	
	public void LoadScene(string name){
		Destroy (this);
		GameManager.contador_de_pontos = 0;
		Application.LoadLevel(name);
		
	}
	
	public void QuitGame(){
        Destroy(gameObject);
		Application.Quit();
        
	}
}
