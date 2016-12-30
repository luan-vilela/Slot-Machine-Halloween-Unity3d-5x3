using UnityEngine;
using System.Collections;

public class cria : MonoBehaviour {

	public Rigidbody2D medusa;
	bool novaBruxa;
	int posicao;

	// Use this for initialization
	void Start () {
		criaMedusa();
		posicao = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.y < -4){ posicao = 1;}
		if(transform.position.y >= 1){ posicao = -1; }
		
				transform.Translate(Vector3.up*posicao*Time.deltaTime);
	}

	void criaMedusa(){
		if(novaBruxa && !andar.terminoBonus){
			Rigidbody2D clone = Instantiate(medusa, transform.position, transform.rotation) as Rigidbody2D;
			novaBruxa = !novaBruxa;
			atraso();
		}
		else{
			atraso();
			novaBruxa = !novaBruxa;
		}
	}
	void atraso(){
		Invoke("criaMedusa",Random.Range(0.5f,3.1f));
	}

}
