
using UnityEngine;
using System.Collections;

public class fogo : MonoBehaviour {

	Transform target;
	// Use this for initialization
	void Start () {

		target = GameObject.FindWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.LookAt(target);
		transform.Translate(-Vector3.forward*-4*Time.deltaTime);
		atraso();


	}


	void destroi(){
		Destroy(gameObject);
	}

	void atraso(){
		Invoke("destroi", 2);
	}

}
