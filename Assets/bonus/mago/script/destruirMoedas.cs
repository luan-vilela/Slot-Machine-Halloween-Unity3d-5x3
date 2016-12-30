using UnityEngine;
using System.Collections;

public class destruirMoedas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Random.rotation;

		if(transform.position.y <= -6){
			Destroy(gameObject);
		}
	}
}
