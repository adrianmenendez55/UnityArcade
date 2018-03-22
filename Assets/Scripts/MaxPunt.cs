using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MaxPunt : MonoBehaviour {

    public Text maxpunt;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		maxpunt.text = "Max punt: " + PlayerPrefs.GetInt("puntuacion");
    }
}
