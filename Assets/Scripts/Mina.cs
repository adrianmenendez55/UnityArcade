using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mina : MonoBehaviour {

    public float vel = 9;

	public Renderer miRend;

	// Use this for initialization
	void Start () {
		Invoke ("Aviso",2);
		Invoke ("Explotar", 3);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * vel;
    }

	void Explotar()
	{
		
		Collider[] lista = Physics.OverlapSphere(this.transform.position, 4.5f);
            foreach (Collider ob in lista){
                Controles c = ob.GetComponent<Controles>();
                if (c != null){
                    Destroy(c.gameObject);
                    SceneManager.LoadScene("GameOver");
                } else{
                Rigidbody rgb = ob.GetComponent<Rigidbody>();
                if (rgb != null){
                    Destroy(rgb.gameObject);
                }
                }
            }
	}

	void Aviso(){
		miRend.material.color = Color.red;
	}
  }

