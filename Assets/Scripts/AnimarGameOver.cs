using UnityEngine;
using System.Collections;

public class AnimarGameOver : MonoBehaviour {

    public float vel = 200.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * vel;
    }
}
