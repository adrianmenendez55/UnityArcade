using UnityEngine;
using System.Collections;

public class PowerUpVida : MonoBehaviour {

	public GameObject expl;

	public float vel = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.left * Time.deltaTime* vel;
	}

    void OnTriggerEnter(Collider c) {
        Controles controles = c.gameObject.GetComponent<Controles>();
        if (controles != null) {
			ManagerLevel.instancia.vidas +=1;
        }
        Destroy(this.gameObject);
		GameObject explosion = Instantiate (expl);
		explosion.transform.position = this.transform.position;
    }
}
