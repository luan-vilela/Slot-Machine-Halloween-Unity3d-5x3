using UnityEngine;
using System.Collections;

public class tiraGiroFogo : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(transform.rotation.x != 0 || transform.rotation.y != 0){
			transform.rotation = Quaternion.Euler(0,0,transform.rotation.z);
		}
	}
}
