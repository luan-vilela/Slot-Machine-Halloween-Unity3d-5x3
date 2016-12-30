using UnityEngine;
using System.Collections;

public class destroiObj : MonoBehaviour {
	int cont;
	public static bool caiu;
	// Use this for initialization
	void Start () {
		cont = -90;
		caiu = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(cont <= 10){
			transform.Rotate(Random.Range(0,20),Random.Range(0,20),Random.Range(0,20));
		}

		cont++;
		

		if(transform.position.y < -2.0f){
			Destroy(gameObject);
			caiu = true;
			lancaDado.jogar = true;
		}

	}
}
