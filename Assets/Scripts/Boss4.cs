using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss4 : MonoBehaviour {

    /*public float vel = 2;*/
    public int vidasBoss = 10;

    public GameObject balaEnemiga;
    public GameObject posDisparo;
    public float fuerzaDisparo = 500.0f;
    public float tiempoDisparo = 1.0f;

	public Renderer rendBoss;

	public float tiempoEspera = 5.0f;
	public bool invencible = false;

	public AudioSource audioDano;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparar", tiempoDisparo, tiempoDisparo);
    }
	
	// Update is called once per frame
	void Update () {
        /*this.transform.position += Vector3.left * Time.deltaTime * vel;*/
    }

    void OnTriggerEnter(Collider c){
		BalaNave bala = c.gameObject.GetComponent<BalaNave> ();
			if (bala != null) {
				audioDano.Play ();
        		vidasBoss--;

			if (vidasBoss < 5) {
				rendBoss.material.color = Color.red;
				InvokeRepeating ("Disparar", 0.5f, 0.5f);
				if (invencible == false) {
					StartCoroutine ("Invencible");
				}
			}

			if (vidasBoss < 1) { 
				SceneManager.LoadScene (11);
			}
 	 	}
	}


	void Disparar(){
		GameObject newbala = Instantiate(balaEnemiga);
		newbala.transform.position = posDisparo.transform.position;
		Rigidbody rgb = newbala.GetComponent<Rigidbody>();
		Vector3 dirFuerza = new Vector3 (-posDisparo.transform.right.x, -posDisparo.transform.right.y, -posDisparo.transform.right.z) * fuerzaDisparo;
		rgb.AddForce(dirFuerza);
	}

	IEnumerator Invencible(){
		invencible = true;
		int vidaAhora = vidasBoss;
		vidasBoss = 9999;
		yield return new WaitForSeconds (tiempoEspera);
		vidasBoss = vidaAhora;
		yield return new WaitForSeconds (tiempoEspera);
		invencible = false;

	}
}
