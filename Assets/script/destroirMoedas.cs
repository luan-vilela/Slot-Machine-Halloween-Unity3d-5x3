using UnityEngine;
using System.Collections;

public class destroirMoedas : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(Random.Range(0,1.1f),Random.Range(0,1.1f),Random.Range(0,1.1f)));
		if(transform.position.y <= -5){
			Destroy(gameObject);
		}

	}
}
