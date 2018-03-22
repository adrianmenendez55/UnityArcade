using UnityEngine;
using System.Collections;

public class Disp : MonoBehaviour {

	public GameObject bala1;
	public float force;

	public int cantidadRafaga = 4; // Número de balas que disparas en la ráfaga
	public int contadorRafaga = 0; // Balas disparadas en la ráfaga
	public float tiempoRafaga = 0.1f; // Tiempo entre balas en la ráfaga

	public enum TipoDisparo {normal, angular3, escopeta, rafaga};

    public AudioSource audioDisparo;

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Mod1 ();
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			Mod2 ();
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Mod3 ();
		}
		if (Input.GetKeyDown (KeyCode.F) && contadorRafaga == 0) {
			Mod4 ();
		}
	}

	// Disparo normal
	void Mod1()
	{
		CreaDisp (this.transform.position, this.transform.right, force);
	}

	// Triple angular
	void Mod2()
	{
		CreaDisp (this.transform.position, this.transform.right, force);
		CreaDisp (this.transform.position, this.transform.right+this.transform.up/2, force);
		CreaDisp (this.transform.position, this.transform.right-this.transform.up/2, force);
	}

	// Escopeta
	void Mod3()
	{
		for (int x = 0; x < 10; x++) {
			Vector3 cambio = this.transform.up * Random.Range (-1f, 1f);
			cambio = (this.transform.right + cambio).normalized;
			cambio = cambio * Random.Range (0.9f, 1.1f);
			CreaDisp (this.transform.position, (this.transform.right+cambio).normalized, force);
		}
	}

	// Ráfaga
	void Mod4(){
		// Si se han disparado todas las balas de la ráfaga, se acaba
		if (contadorRafaga >= cantidadRafaga) {
			contadorRafaga = 0;
			return;
		}
		CreaDisp (this.transform.position, this.transform.right, force);
		Invoke ("Mod4", tiempoRafaga);
		contadorRafaga++;

	}

	void CreaDisp(Vector3 pos, Vector3 dir, float f)
	{
        audioDisparo.Play();
		GameObject newBala = Instantiate (bala1);
		newBala.transform.position = pos;
		newBala.GetComponent<Rigidbody>().AddForce(dir*f,ForceMode.Impulse);
		Destroy (newBala,3);
	}
}
