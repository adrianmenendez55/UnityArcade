using UnityEngine;
using System.Collections;

public class Esparcidor : MonoBehaviour {

    public int vidasEnemigo = 1;

    public float vel = 2;

    public GameObject balaEnemiga;
    public GameObject posDisparoLeft;
    public GameObject posDisparoRight;
    public GameObject posDisparoUp;
    public GameObject posDisparoDown;
    public float fuerzaDisparo;
    public float tiempoDisparo = 5.0f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("DispararLeft", tiempoDisparo, tiempoDisparo);
        InvokeRepeating("DispararRight", tiempoDisparo, tiempoDisparo);
        InvokeRepeating("DispararUp", tiempoDisparo, tiempoDisparo);
        InvokeRepeating("DispararDown", tiempoDisparo, tiempoDisparo);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * vel;
        
    }

    void OnTriggerEnter(Collider c)
    {
        BalaNave bala = c.gameObject.GetComponent<BalaNave>();
        if (bala != null)
        {

            vidasEnemigo--;
            if (vidasEnemigo < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void DispararLeft()
    {
        GameObject newbala = Instantiate(balaEnemiga);
        newbala.transform.position = posDisparoLeft.transform.position;
        Rigidbody rgb = newbala.GetComponent<Rigidbody>();
        Vector3 dirFuerza = new Vector3(-posDisparoLeft.transform.right.x, posDisparoLeft.transform.right.y, posDisparoLeft.transform.right.z) * fuerzaDisparo;
        rgb.AddForce(dirFuerza);
    }

    void DispararRight()
    {
        GameObject newbala = Instantiate(balaEnemiga);
        newbala.transform.position = posDisparoRight.transform.position;
        Rigidbody rgb = newbala.GetComponent<Rigidbody>();
        Vector3 dirFuerza = new Vector3(posDisparoRight.transform.right.x, posDisparoRight.transform.right.y, posDisparoRight.transform.right.z) * fuerzaDisparo;
        rgb.AddForce(dirFuerza);
    }

    void DispararUp()
    {
        GameObject newbala = Instantiate(balaEnemiga);
        newbala.transform.position = posDisparoUp.transform.position;
        Rigidbody rgb = newbala.GetComponent<Rigidbody>();
        Vector3 dirFuerza = new Vector3(posDisparoUp.transform.up.x, posDisparoUp.transform.up.y, posDisparoUp.transform.up.z) * fuerzaDisparo;
        rgb.AddForce(dirFuerza);
    }

    void DispararDown()
    {
        GameObject newbala = Instantiate(balaEnemiga);
        newbala.transform.position = posDisparoDown.transform.position;
        Rigidbody rgb = newbala.GetComponent<Rigidbody>();
        Vector3 dirFuerza = new Vector3(- posDisparoDown.transform.up.x, - posDisparoDown.transform.up.y, -posDisparoDown.transform.up.z) * fuerzaDisparo;
        rgb.AddForce(dirFuerza);
    }
}
