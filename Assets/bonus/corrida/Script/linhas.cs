using UnityEngine;
using System.Collections;

public class linhas : MonoBehaviour {
		
	bool ativado;

	void FixedUpdate(){

		if(variaveisCorrer.selecaoBruxa == "" + 0){
			gameObject.renderer.enabled = true;
			transform.position = new Vector2(Random.Range(-5.5f,-5.4f),transform.position.y);
		}
		else{
			if(!ativado){
				ativado = true;
				if(gameObject.tag != variaveisCorrer.selecaoBruxa)
				gameObject.renderer.enabled = false;
			}

		}





	




	}
}
