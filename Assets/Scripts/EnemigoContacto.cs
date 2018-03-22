using UnityEngine;
using System.Collections;

public class EnemigoContacto : MonoBehaviour {

    public float vel = 2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * vel;
    }

    void OnTriggerEnter(Collider c) {
        BalaNave balaN = c.gameObject.GetComponent<BalaNave>();
		if (balaN != null) {
        Destroy(this.gameObject);
		}

        Controles cont = c.gameObject.GetComponent<Controles>();
        if (cont != null) {
            ManagerLevel.instancia.vidas--;
            Destroy(this.gameObject);
        }
    }
}
