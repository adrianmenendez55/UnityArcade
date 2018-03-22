using UnityEngine;
using System.Collections;

// Que es lo que puede pasar (oleada1, oleada2...)
public enum tipoEvento{wait ,wave1, wave2, wave3, item1}

[System.Serializable]
public class evento {
	
	public tipoEvento elTipo; // Que tipo de evento es este

	public Vector3 posInicio = new Vector3 (11, 4, 0); // Donde pasará el evento

	public int cuantas = 4; // Cuántos habrá

	public float siguiente; // Tiempo para el siguiente evento
}

public class GestorCreacionEnemigos : MonoBehaviour {

	public evento[] losEventos; // Array con los eventos del nivel
	public int currentEvent = -1; // Variable que me indica qué evento está en curso

	public GameObject enemy1;

	// Use this for initialization
	void Start () {
		currentEvent = -1;
		GestionarEvento ();
	}

	void GestionarEvento(){
		currentEvent++;
		if (currentEvent >= losEventos.Length)
			return; // Ya se paso todo el array
		
		// Guardo que tipo de eventos es lo que toca
		tipoEvento tipoActual = losEventos [currentEvent].elTipo;
		// Evaluar cada caso
		switch(tipoActual){
		case tipoEvento.wave1:
			Wave1 ();
			/*Debug.Log ("Hace W1");*/
			break;
		case tipoEvento.wave2:
			/*Debug.Log ("Hace W2");*/
			StartCoroutine (Wave2());
			break;
		case tipoEvento.wave3:
			Wave3 ();
			/*Debug.Log ("Hace W3");*/
			break;
		case tipoEvento.item1:
			/*Debug.Log ("Hace I1");*/
			break;
		case tipoEvento.wait:
			StartCoroutine (Wait());
			/*Debug.Log ("Hace wait");*/
			break;
		}
		// El ciclo solo se hace en los casos que no sean el Wait
		if (losEventos[currentEvent].elTipo != tipoEvento.wait){
		//Gestionar el siguiente evento cuando toque
		float espera = losEventos[currentEvent].siguiente;
		Invoke ("GestionarEvento", espera);
		// Actualizar para el siguiente evento
		}
	}

	void Wave1(){
		Vector3 pos = losEventos [currentEvent].posInicio;
		for (int x = 0; x < losEventos[currentEvent].cuantas; x++) {
			GameObject nuevoEnemigo = Instantiate (enemy1); // Creamos clon
			nuevoEnemigo.transform.position = pos; //Cambio pos
			pos += 2*Vector3.down; // Cambio valor pos
		}
	}

	IEnumerator Wave2(){
		Vector3 pos = losEventos [currentEvent].posInicio;
		for (int x = 0; x < 4; x++) {
			GameObject nuevoEnemigo = Instantiate (enemy1); // Creamos clon
			nuevoEnemigo.transform.position = pos; //Cambio pos
			pos += 2*Vector3.down; // Cambio valor pos
			yield return new WaitForSeconds(0.4f);
		}
	}

	void Wave3(){
		Vector3 pos = losEventos [currentEvent].posInicio;
		for (int x = 0; x < losEventos[currentEvent].cuantas; x++) {
			GameObject nuevoEnemigo = Instantiate (enemy1); // Creamos clon
			nuevoEnemigo.transform.position = pos; //Cambio pos
			pos += 2*Vector3.down; // Cambio valor pos
		}
	}

	IEnumerator Wait(){
		// Detectar los enemigos de la escena
		GameObject[] losEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
		bool todosDestruidos = false;
		// Mientras no estén todos destruidos
		while(!todosDestruidos) {
			// Hacer que checking
			todosDestruidos = true; // Premisa: todos los enemigos están destruidos
			foreach (GameObject enemy in losEnemigos) {
				if (enemy != null) { // El enemigo no está destruido
					todosDestruidos = false;
				} 
			}
			yield return new WaitForSeconds (0.25f);
		}
		//Gestionar el siguiente evento cuando toque
		float espera = losEventos[currentEvent].siguiente;
		Invoke ("GestionarEvento", espera);
		// Actualizar para el siguiente evento
	}
}
