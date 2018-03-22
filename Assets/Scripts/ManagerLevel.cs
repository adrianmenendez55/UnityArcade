using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerLevel : MonoBehaviour {

	/*public GameObject fondo;*/
	public float distanciaNivel;
	public float distanciaFondo;

	public GameObject bola;
	public int numeroBolas;
	public float distanciaBolas;

	public int vidas;
	public int puntuacion = 0;
	public int dificultad;
	public int numeroNivel;
    public float velocidadNave = 100.0f;

	public static ManagerLevel instancia;

    public Text vidasNave;
    public Text puntosNave;

	// Use this for initialization
	void Start () {
		instancia = this;
		GenerarEnemigos ();
        vidasNave.text = "Vidas: " + vidas;
        puntosNave.text = "Puntos: " + puntuacion;
		/*GenerarBolitas ();*/
	}
	
	// Update is called once per frame
	void Update () {
        vidasNave.text = "Vidas: " + vidas;
		puntosNave.text = "Puntos: " + puntuacion;
       
    }

	public void GenerarEnemigos(){
		/*Debug.Log ("Termino de generar enemigos");*/
	}

    public void SumarPuntos()
    {
        puntuacion += 15;
        if (puntuacion > PlayerPrefs.GetInt("puntuacion")) {
            PlayerPrefs.SetInt("puntuacion", puntuacion);
            PlayerPrefs.Save();
        } else
        {
            puntosNave.text = "puntuacion:" + puntuacion;
        }
}
}