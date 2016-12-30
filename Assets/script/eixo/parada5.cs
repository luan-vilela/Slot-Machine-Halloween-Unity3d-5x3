/*
para a roleta quando chegar em tempo 50

 */


using UnityEngine;
using System.Collections;


	
public class parada5 : MonoBehaviour {
	
	public static bool teste = true;

	void OnTriggerEnter(Collider obj){

		if(rodarRoleta5.tempo == 0){
			teste = false;
			rodarRoleta5.tempo = 0;

		}
		else{
			teste = true;
		}
	}
	
}
