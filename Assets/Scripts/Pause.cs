using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Pausar el juego
		if(Input.GetKeyDown(KeyCode.P)){
			Time.timeScale = 0;
		}
		// Quitar la pausa
		if(Input.GetKeyDown(KeyCode.O)){
			Time.timeScale = 1;
		}
	
	}
}
