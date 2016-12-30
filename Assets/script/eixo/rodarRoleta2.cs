using UnityEngine;
using System.Collections;

public class rodarRoleta2 : MonoBehaviour {

	public static float tempo;
	bool entraAtraso;
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
	}
	void paradaTempo(){
		entraAtraso = false;
		tempo = 0;
		audio.PlayOneShot(parada, 1.0f);
		transform.rotation = new Quaternion(0,0,0,0);
	}
	void atraso(){
		Invoke("paradaTempo",bancoDados.rotacao*1.1f);
	}
}
