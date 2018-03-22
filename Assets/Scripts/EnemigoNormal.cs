using UnityEngine;
using System.Collections;

public class EnemigoNormal : MonoBehaviour {

    public int vidasEnemigo = 1;

    public float vel = 2;
    public int contadorBalas = 5;

    public GameObject balaEnemiga;
    public GameObject posDisparo;
    public float fuerzaDisparo;
    public float tiempoDisparo = 3.0f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparar", tiempoDisparo, tiempoDisparo);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * vel;
    }

    void OnTriggerEnter(Collider c)
    {
		BalaNave bala = c.gameObject.GetComponent<BalaNave> ();
		if (bala != null) {

        vidasEnemigo--;
        if (vidasEnemigo < 1){
            Destroy(this.gameObject);
        }
		}
    }

    void Disparar(){

        GameObject newbala = Instantiate(balaEnemiga);
        newbala.transform.position = posDisparo.transform.position;
        Rigidbody rgb = newbala.GetComponent<Rigidbody>();
        Vector3 dirFuerza = new Vector3 (posDisparo.transform.forward.x, posDisparo.transform.forward.y, posDisparo.transform.forward.z) * fuerzaDisparo;
        rgb.AddForce(dirFuerza);
    }
}
