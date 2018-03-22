using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraCarga : MonoBehaviour {

	public AsyncOperation asynOp;

	public Transform pivoteBarra;

	// Use this for initialization
	void Start () {
		asynOp =SceneManager.LoadSceneAsync ("Select_Lvl");

        Debug.Log("Progreso 0%");
		pivoteBarra.localScale = new Vector3 (0.0f, pivoteBarra.localScale.y, pivoteBarra.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		pivoteBarra.localScale = new Vector3 (asynOp.progress, pivoteBarra.localScale.y, pivoteBarra.localScale.z);
        Debug.Log("Progreso 100%");
	}
}
