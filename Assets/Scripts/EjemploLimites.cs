using UnityEngine;
using System.Collections;

public class EjemploLimites : MonoBehaviour {
	// Componente camera que esta renderizando el juego
	public Camera cam;

	// Use this for initialization
	void Start () {
		// Transforma la posición del espacio de la pantalla al espacio del mundo
		this.transform.position = cam.ScreenToWorldPoint (new Vector3(0,0,10));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
