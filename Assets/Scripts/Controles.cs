using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Controles : MonoBehaviour {

	public Rigidbody rgb;
	public float speedForce = 15.0f;
	public float movex;
	public float movey;
	public float vel;

	public float limUp;
	public float limDown;
	public float limLeft;
	public float limRight;

	// Posiciones del avión
	public Vector3 rotNormal;
	public Vector3 rotIzq;
	public Vector3 rotDcha;
	public float velRot = 2;

	public Camera cam;

	public static Controles instancia;

	public AudioSource audioDano;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ();
		limDown = cam.ScreenToWorldPoint (new Vector3(0,0,10)).y+0.5f;
		limLeft = cam.ScreenToWorldPoint (new Vector3(0,0,10)).x+0.5f;
		limRight = cam.ScreenToWorldPoint (new Vector3(Screen.width, cam.pixelHeight, 10)).x-0.5f;
		limUp = cam.ScreenToWorldPoint (new Vector3(Screen.width, cam.pixelHeight, 10)).y-0.5f;


	}
	
	// Update is called once per frame
	void Update () {

        rgb.velocity = Vector3.zero;

		if (Input.GetKey(KeyCode.W)) {
			rgb.velocity += Vector3.up * vel;
			// this.transform.position += Vector3.up * vel * Time.deltaTime; <- Otra forma, por posición
		}
		if (Input.GetKey(KeyCode.S)) {
			rgb.velocity += Vector3.down * vel;

		}
		if (Input.GetKey(KeyCode.A)) {
			rgb.velocity += Vector3.left * vel;
		}
		if (Input.GetKey(KeyCode.D)) {
			rgb.velocity += Vector3.right * vel;
		}

		Limites ();
		Rotacion ();
	}

	void Limites(){
		Vector3 posArreglada = new Vector3(
			// Mathf.Clamp agarra un valor entre un máximo y un mínimo
			Mathf.Clamp(this.transform.position.x,limLeft,limRight),
			Mathf.Clamp(this.transform.position.y,limDown,limUp),
			this.transform.position.z);
		this.transform.position = posArreglada;
	}

	void Rotacion(){
		Quaternion rotDeseada;

		rotDeseada = Quaternion.Euler (rotNormal);

		if(Input.GetKey(KeyCode.W)){
			rotDeseada = Quaternion.Euler (rotIzq);	// Traduce euleanas a quaterniones
		}
		if(Input.GetKey(KeyCode.S)){
			rotDeseada = Quaternion.Euler (rotDcha);
		}
		// Lerpear
		this.transform.rotation = Quaternion.Lerp (this.transform.rotation, rotDeseada, velRot * Time.deltaTime);
  }

  void OnTriggerEnter(Collider c) {
		BalaEnemiga balaenem = c.gameObject.GetComponent<BalaEnemiga> ();
		if (balaenem != null) {
			audioDano.Play ();
		}

        if (ManagerLevel.instancia.vidas <= 1){
			
            Destroy(this.gameObject);
			SceneManager.LoadScene (2);
          }
	   }
    }
