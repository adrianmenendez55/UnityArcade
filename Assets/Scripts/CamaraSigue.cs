using UnityEngine;
using System.Collections;

public class CamaraSigue : MonoBehaviour {
	public Transform objetivo;
	public Vector3 dist;
	public float vellerp = 3;

	// Use this for initialization
	void Start () {
		dist = this.transform.position - objetivo.transform.position;
	}

	// Update is called once per frame
	void Update () {
		Vector3 posDeseada = objetivo.position + dist;
		this.transform.position = Vector3.Lerp (this.transform.position, posDeseada, vellerp * Time.deltaTime);
	}
}