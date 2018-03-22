using UnityEngine;
using System.Collections;

[System.Serializable]
public class regla {
	public KeyCode kd; // Botón de interés
	public float lim; // Límite de tiempo sin ser usado
	public float cont; // Contador de tiempo sin ser usado
	public string mensaje; // Mensaje de aviso/chequeo

	public KeyCode kdIncompatible; // En caso de usar inputs incorrectos
	public string mensajeIncompatible;
}

public class TutorialInput : MonoBehaviour {

	public regla[] lasReglas; // Reglas básicas de input definidas para el juego/software

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (regla r in lasReglas) {
			// Por cada elemento del array
			if (Input.GetKey (r.kd)) {
				r.cont = 0; // Se reinicia la cuenta

				// Evaluar caso incompatible
				if (r.kdIncompatible != null && Input.GetKey(r.kdIncompatible)){
					Debug.Log(r.mensajeIncompatible);
				}

			} else {
				r.cont += Time.deltaTime; // Si no se pulsa, contar el tiempo
				if(r.cont > r.lim) {
					// El tiempo sin ser usado superó el límite
					Debug.Log (r.mensaje);
					r.cont = 0; // Reiniciar la cuenta
				}
			}
		}
	}
}