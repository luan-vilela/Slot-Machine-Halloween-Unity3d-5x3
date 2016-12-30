
using UnityEngine;
using System.Collections;

public class variaveis : MonoBehaviour {

	public Texture2D[] imag = new Texture2D[10];
	public static Texture2D[] imagem = new Texture2D[10];

	public Texture2D[] imagGanho = new Texture2D[10];
	public static Texture2D[] imagemGanho = new Texture2D[10];
	

	void Start(){
		for(int i = 0; i <= 9;i++){
			imagem[i] = imag[i];
			imagemGanho[i] = imagGanho[i];
		}
	}

	void Update(){
		if(rodarRoleta5.tempo == 0){
			audio.Stop();
		}
		if(rodarRoleta5.tempo != 0 && rodarRoleta5.entra){
			audio.Play();
		}

	}
}
