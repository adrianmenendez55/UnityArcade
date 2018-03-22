using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {

	public GameObject bala1;
	public float force;
	public int contadorBalas = 5;  // Balas disparadas

	public float tiempoRafaga = 0.5f;
	public float tiempoEspera = 2.0f;
	public GameObject posDisparoEnemy;
	public GameObject jugador;

	public Vector3 objetivo;

	public Rigidbody rgb;

	public float velLerp;

    

	// Use this for initialization
	void Start () {
		StartCoroutine ("Enemy");
		rgb = this.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
        // Apuntar al jugador, actualizando la posición
        objetivo = (jugador.transform.position - posDisparoEnemy.transform.position).normalized;
	}

	// Método de disparo
	void CrearDisparo(Vector3 posicion, Vector3 dir, float f){
		GameObject nuevabala = Instantiate (bala1);
		nuevabala.transform.position = posicion;
		nuevabala.GetComponent<Rigidbody> ().AddForce (dir*f,ForceMode.Impulse);
		Destroy (nuevabala,3);
		
	}

	IEnumerator Enemy(){
		// Ejecutar la ráfaga, que se repite tras el tiempo de espera
		for (int x=0; x<=contadorBalas; x++) {
			CrearDisparo (this.transform.position, objetivo, force);
			yield return new WaitForSeconds (tiempoRafaga);
		}
		StartCoroutine ("Esperar");
    }

	IEnumerator Esperar(){
		yield return new WaitForSeconds (tiempoEspera);
		StartCoroutine ("Mover3");
	}

	/*IEnumerator Moverse(){
		float velX = Random.Range (-3.0f, 3.0f);
		float velY = Random.Range (-3.0f, 3.0f);

		rgb.velocity = new Vector3(velX,velY,0); // Empezar a moverse con la velocidad asignada
		yield return new WaitForSeconds(1); // Interrumpimos la ejecución y esperamos 1 seg.
		rgb.velocity = Vector3.zero; // Para

		StartCoroutine ("Enemy");
	}*/

	/*IEnumerator Mover2(){
		float tiempoInicial = Time.time;
		float velX = Random.Range (-3.0f, 3.0f);
		float velY = Random.Range (-3.0f, 3.0f);

		while(Time.time < tiempoInicial + 2){
			this.transform.Translate (new Vector3 (velX,velY,0)*Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate ();
		}
		StartCoroutine ("Enemy");
	}*/
		
	IEnumerator Mover3(){
		// Calculamos la posición de destino
		float posX = Random.Range (-10f, 10f);
		float posY = Random.Range (-6f, 6f);
		Vector3 destino = new Vector3 (posX, posY);

		while(Vector3.Distance(this.transform.position, destino) > 0.1f){
			this.transform.position = Vector3.Lerp (this.transform.position, destino, velLerp*Time.fixedDeltaTime);
			yield return new WaitForFixedUpdate ();
		}
		StartCoroutine ("Enemy");
	}

    
}
