using UnityEngine;
using System.Collections;

public class PowerUpInvencible : MonoBehaviour {

    public bool invencible = false;

    public float tiempoInvencible;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (invencible == false){
            StartCoroutine("Inmortal");
        }
	}

    void OnTriggerEnter(Collider c)
    {
        Destroy(this.gameObject);
    }

    IEnumerator Inmortal() {
        invencible = true;
        int vidaAhora = ManagerLevel.instancia.vidas;
        ManagerLevel.instancia.vidas = 9999;
        yield return new WaitForSeconds(tiempoInvencible);
        ManagerLevel.instancia.vidas = vidaAhora;
        yield return new WaitForSeconds(tiempoInvencible);
        invencible = false;
    }
}
