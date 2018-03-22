using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour {
	
	public Button btnContinuar;

	// Use this for initialization
	void Start () {
		// Obtenemos hasta donde está desbloqueado el juego
		int lastLevel = PlayerPrefs.GetInt ("Desbloqueado");

		// El botón pertenece a un nivel que aún no se ha desbloqueado
		if(lastLevel == 0){
			btnContinuar.interactable = false; // Botón bloqueado
		}
	}

	public void Nueva(){
		// Primer nivel desbloqueado
		PlayerPrefs.SetInt ("Desbloqueado", 1);
		// Cargar escena de selección
		//SceneManager.LoadScene ("Select_Lvl");
		SceneManager.LoadScene ("Carga");
	}

	public void Continuar(){
		//SceneManager.LoadScene ("Select_Lvl");
		SceneManager.LoadScene ("Carga");
	}
}
