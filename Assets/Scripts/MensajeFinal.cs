using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MensajeFinal : MonoBehaviour {

    public Text textoParpadea;
    string textoGanador = "¡TE PASASTE EL JUEGO!";
    string textoBlanco = "";

    bool estaParpadeando = true;

	// Use this for initialization
	void Start () {
        textoParpadea.GetComponent<Text>();

        StartCoroutine("Parpadear");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Parpadear(){
        while (estaParpadeando)
        {
            textoParpadea.text = textoBlanco;
            yield return new WaitForSeconds(0.5f);
            textoParpadea.text = textoGanador;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
