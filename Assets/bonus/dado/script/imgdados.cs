using UnityEngine;
using System.Collections;

public class imgdados : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!lancaDado.jogar){
			gameObject.renderer.enabled = false;
		}
		else{
			gameObject.renderer.enabled = true;
		}
	}

}
