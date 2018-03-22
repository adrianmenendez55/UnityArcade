using UnityEngine;
using System.Collections;

public class BalaNave : MonoBehaviour {

	public GameObject chispas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c) {
		GameObject part = Instantiate (chispas);
		part.transform.position = this.transform.position;
        Destruir();

    }

    void Destruir() {
        Destroy(this.gameObject);
    }
}
