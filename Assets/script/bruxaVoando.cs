using UnityEngine;
using System.Collections;

public class bruxaVoando : MonoBehaviour {
	int direcao;
	// Update is called once per frame
	void Update () {

		if(bancoDados.premio > (3*layout.tecla*bancoDados.aposta*bancoDados.valorAposta)){
			transform.Rotate(0,15,0);
		}


		if(rodarRoleta5.tempo != 0){
			gameObject.transform.Translate(-Random.Range(0.1f,2.0f)*Time.deltaTime,0,0);
			if(direcao > 5){
				transform.rotation = Quaternion.Euler(0,180,0);
			}
			else{
				transform.rotation = Quaternion.Euler(0,0,0);
			}

		}
		else{
			direcao = Random.Range(0,11);
		}

		if(transform.position.x < -4.002501f ){

			transform.rotation = Quaternion.Euler(0,180,0);
			direcao = 6;
		}
		if(transform.position.x > 3.867014f){
			transform.rotation = Quaternion.Euler(0,0,0);
			direcao = 0;
		}
	}
}
