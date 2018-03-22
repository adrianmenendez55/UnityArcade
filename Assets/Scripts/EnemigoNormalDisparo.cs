using UnityEngine;
using System.Collections;

public class EnemigoNormalDisparo : MonoBehaviour {

	public float vel = 2;

	public GameObject bala1;
	public int contadorBalas = 1;  // Balas disparadas
	public float force;

	public Vector3 objetivo;

	public GameObject posDisparoEnemy;
	public GameObject jugador;

	public float tiempoRafaga = 0.5f;
	public float tiempoEspera = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.left * Time.deltaTime* vel;

		objetivo = (jugador.transform.position - posDisparoEnemy.transform.position).normalized;
	}

	void OnCollisionEnter(Collision c){
		Controles controles = c.gameObject.GetComponent<Controles> ();
		if (controles != null) {
			ManagerLevel.instancia.vidas--;
		}
	}

	void Disparo(Vector3 posicion, Vector3 dir, float f){
		GameObject nuevabala = Instantiate (bala1);
		nuevabala.transform.position = posicion;
		nuevabala.GetComponent<Rigidbody> ().AddForce (dir*f,ForceMode.Impulse);
		Destroy (nuevabala,3);

	}

	IEnumerator Enemy(){
		// Ejecutar la ráfaga, que se repite tras el tiempo de espera
		for (int x=0; x<=contadorBalas; x++) {
			Disparo (this.transform.position, objetivo, force);
			yield return new WaitForSeconds (tiempoRafaga);
		}
		StartCoroutine ("Esperar");
	}

	IEnumerator Esperar(){
		yield return new WaitForSeconds (tiempoEspera);
	}

}
