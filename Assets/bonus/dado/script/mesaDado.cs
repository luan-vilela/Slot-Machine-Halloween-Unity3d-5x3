using UnityEngine;
using System.Collections;

public class mesaDado : MonoBehaviour {
	public static int soma =0;

	// Use this for initialization
	void Start () {
		soma = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider numero){
		if(lancaDado.parado){
			lancaDado.parado = false;
			if(numero.collider.tag == "1"){
				soma =6;
			}
			else if(numero.collider.tag == "2"){
				soma =5;
			}
			else if(numero.collider.tag == "3"){
				soma =4;
			}
			else if(numero.collider.tag == "4"){
				soma =3;
			}
			else if(numero.collider.tag == "5"){
				soma =2;
			}
			else if(numero.collider.tag == "6"){
				soma =1;
			}
			else{
				Destroy(GameObject.FindWithTag("dado"));
				lancaDado.emcavalo = true;
				lancaDado.jogar = true;
			}
		}
	}
}
