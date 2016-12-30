using UnityEngine;
using System.Collections;

public class luzBranca : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if(layout.auto || ganhoLinhas.bonus[5] != 0){
			gameObject.light.enabled = false;
		}
		else{
			gameObject.light.enabled = true;
		}
	}
}
