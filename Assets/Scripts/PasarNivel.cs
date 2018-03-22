using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour {

	public int siguienteNivel = 1;

	// Use this for initialization
	void Start () {

	}
	
	public void OnMouseDown(){
		// Gano el nivel

		// Obtener el último nivel desbloqueado
		int lastLevel = PlayerPrefs.GetInt("Desbloqueado");
		// Comprobar que el nuevo nivel no es inferior al máximo de progreso en el juego
		if (siguienteNivel > lastLevel) {
			PlayerPrefs.SetInt ("Desbloqueado", siguienteNivel);
		}
        /*SceneManager.LoadSceneAsync(1);*/
		SceneManager.LoadSceneAsync ("Game"+ siguienteNivel.ToString());
	}
}
