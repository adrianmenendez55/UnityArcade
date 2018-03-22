using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour {

	Rigidbody rgbd;

	public Vector3 pos1;
	public Vector3 pos2;

	Vector3 objetivo;
	Vector3 dir;

	public float speed;

	// Use this for initialization
	void Start () {
		
		rgbd = this.GetComponent<Rigidbody> ();

		objetivo = pos1;
		Vector3 miPosicion = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		dir = objetivo - miPosicion;
		rgbd.AddForce(dir * speed);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 miPosicion = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		if (Vector3.Distance (miPosicion, objetivo) <= 0.1f) {
			if (objetivo == pos1) {
				objetivo = pos2;
			} else {
				objetivo = pos1;
			}
			dir = objetivo - miPosicion;
			rgbd.velocity = Vector3.zero;
			rgbd.AddForce(dir * speed);
		}
	}
}

