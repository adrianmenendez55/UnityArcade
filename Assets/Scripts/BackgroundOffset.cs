using UnityEngine;
using System.Collections;

public class BackgroundOffset : MonoBehaviour {

	private Renderer rdr;
	private float contOffset;
	public float velOffset = 0.15f;

	// Use this for initialization
	void Start () {
		// Referencia del componente
		rdr = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		contOffset += velOffset * Time.deltaTime;
		rdr.material.SetTextureOffset ("_MainTex", new Vector2(contOffset, 0f));
	}
}
