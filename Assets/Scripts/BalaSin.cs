using UnityEngine;
using System.Collections;

public class BalaSin : MonoBehaviour {

	public float ratio = 1;
	public float altura = 1;

	public float iniTime;
	// public float desfase = 0;

	// Use this for initialization
	void Start () {
		iniTime = Time.time;					
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0, altura * Mathf.Sin((Time.time)* ratio), 0);
	}
}
