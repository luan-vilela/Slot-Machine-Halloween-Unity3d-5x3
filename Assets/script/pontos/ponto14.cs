using UnityEngine;
using System.Collections;

public class ponto14 : MonoBehaviour {

	public static string ponto;
	bool teste = true;
	public static int salvaArmazena;
	public static bool liberaSelecao;
	
	
	void OnTriggerStay(Collider obj){
		if( rodarRoleta5.tempo == 0 && teste){
			ponto = obj.renderer.material.mainTexture + "";
			teste = false;
			
			if(ponto == "slot01c (UnityEngine.Texture2D)"){
				salvaArmazena = 0;
			}
			if(ponto == "slot02c (UnityEngine.Texture2D)"){
				salvaArmazena = 1;
			}
			if(ponto == "slot03c (UnityEngine.Texture2D)"){
				salvaArmazena = 2;
			}
			if(ponto == "slot04c (UnityEngine.Texture2D)"){
				salvaArmazena = 3;
			}
			if(ponto == "slot05c (UnityEngine.Texture2D)"){
				salvaArmazena = 4;
			}
			if(ponto == "slot06c (UnityEngine.Texture2D)"){
				salvaArmazena = 5;
			}
			if(ponto == "slot07c (UnityEngine.Texture2D)"){
				salvaArmazena = 6;
			}
			if(ponto == "slot08c (UnityEngine.Texture2D)"){
				salvaArmazena = 7;
			}
			if(ponto == "slot09c (UnityEngine.Texture2D)"){
				salvaArmazena = 8;
			}
			if(ponto == "slot10c (UnityEngine.Texture2D)"){
				salvaArmazena = 9;
			}
		}
		if(obj.gameObject.renderer.material.mainTexture == null)
			obj.gameObject.renderer.material.mainTexture = variaveis.imagem[salvaArmazena];
		
		if(liberaSelecao){
			obj.gameObject.renderer.material.mainTexture = variaveis.imagemGanho[salvaArmazena];
		}
		
		if(rodarRoleta5.tempo != 0){
			teste = true;
			liberaSelecao = false;
		}
		
	}
}
