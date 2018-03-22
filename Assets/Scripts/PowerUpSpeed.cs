using UnityEngine;
using System.Collections;

public class PowerUpSpeed : MonoBehaviour {

    public GameObject luz;

	public float vel = 2;

    public bool isSpeed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.left * Time.deltaTime* vel;
	}

	void OnTriggerEnter(Collider c){
		Controles controles = c.gameObject.GetComponent<Controles> ();
		if (controles != null) {
            if(isSpeed == false)
            {
                StartCoroutine("Speed");
            }
		}
        Destroy(this.gameObject);
        GameObject explo = Instantiate(luz);
        explo.transform.position = this.transform.position;
	}

    IEnumerator Speed(){
        isSpeed = true;
        float velocidadAhora = ManagerLevel.instancia.velocidadNave;
        ManagerLevel.instancia.velocidadNave *= 2;
        yield return new WaitForSeconds(3.0f);
        velocidadAhora = ManagerLevel.instancia.velocidadNave;
        yield return new WaitForSeconds(3.0f);
        isSpeed = false;

    }
}
