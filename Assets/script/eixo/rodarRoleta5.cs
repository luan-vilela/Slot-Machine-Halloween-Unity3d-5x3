using UnityEngine;
using System.Collections;

public class rodarRoleta5 : MonoBehaviour {
	
	public static float tempo;
	int cont;
	public static bool entra, entraAtraso;
	public AudioClip parada;
	
	// Update is called once per frame
	void Update () {

		if(tempo < 0){
			tempo--;
			if(tempo <= -100){
				tempo = 250;
			}
		}
		if(tempo >= 200){
			tempo +=5;
		}
		transform.Rotate(-Vector3.right * tempo * Time.deltaTime);
		if(!entraAtraso && tempo != 0){
			entraAtraso= true;
			atraso();
		}
		if(rodarRoleta5.tempo != 0 && entra){
			entra = false;
		}
		if(rodarRoleta5.tempo == 0){
			entra = true;
		}
	}

	void paradaTempo(){
		entraAtraso = false;
		transform.rotation = new Quaternion(0,0,0,0);
		tempo = 0;
		audio.PlayOneShot(parada, 1.0f);
	}
	void atraso(){
		Invoke("paradaTempo",bancoDados.rotacao*1.4f);
	}
}
