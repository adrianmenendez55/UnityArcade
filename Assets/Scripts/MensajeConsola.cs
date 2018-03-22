using UnityEngine;
using System.Collections;

public class MensajeConsola : MonoBehaviour {

	public string mensaje;

	void Awake(){
		Debug.Log (mensaje);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
