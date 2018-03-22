using UnityEngine;
using System.Collections;

public class BalaEnemiga : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {
		Controles controles = coll.gameObject.GetComponent<Controles> ();
		if (controles != null) {
		ManagerLevel.instancia.vidas--;
        Destroy(this.gameObject);
		}
    }
}
