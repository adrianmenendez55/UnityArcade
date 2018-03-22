using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonNivel : MonoBehaviour {
	// Indica a qué nivel corresponde este botón
	public int numNivel;

	public Button elBoton;

	// Use this for initialization
	void Start () {
		// Obtenemos hasta donde está desbloqueado el juego
		int lastLevel = PlayerPrefs.GetInt ("Desbloqueado");

		// Obtenemos la referencia del botón
		elBoton = this.GetComponent<Button>();
		// El botón pertenece a un nivel que aún no se ha desbloqueado
		if(numNivel > lastLevel){
			elBoton.interactable = false; // Botón bloqueado
		}
		// Indico el metodo a ejecutar
		elBoton.onClick.AddListener (CargarNivel);
	}

	void CargarNivel(){
		SceneManager.LoadScene ("Game" + numNivel.ToString());
	}
}
