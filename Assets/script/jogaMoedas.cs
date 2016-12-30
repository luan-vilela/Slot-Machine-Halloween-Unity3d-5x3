using UnityEngine;
using System.Collections;

public class jogaMoedas : MonoBehaviour {

	public Rigidbody moedas;
	public static bool ativa, ativaMaquina;
	Rigidbody clone;

	void FixedUpdate(){
		if(bancoDados.premio > (4*layout.tecla*bancoDados.aposta*bancoDados.valorAposta) && !ativaMaquina){
			ativa = !ativa;
			chamaMoedas();
		}
		else if(bancoDados.premio > (3*layout.tecla*bancoDados.aposta*bancoDados.valorAposta) && !ativa){
			ativa = !ativa;
			int ran = Random.Range(1,5);
			for(int i = 0; i <= ran; i++){
				clone = Instantiate(moedas,transform.position,transform.rotation) as Rigidbody;
				clone.velocity = transform.TransformDirection(0,Random.Range(2.0f,10.0f),0);
			}
		}
		else{
			ativaMaquina = false;
		}

	}


	void chamaMoedas(){
		clone = Instantiate(moedas,transform.position,transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection(Random.Range(-5,6),Random.Range(1.0f,10.0f),Random.Range(-4,5));
	}
}
