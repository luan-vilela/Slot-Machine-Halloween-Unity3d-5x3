using UnityEngine;
using System.Collections;

public class roletaImag1 : MonoBehaviour {
	
	public int[] travaImagem = new int[10];
	public Texture2D[] img = new Texture2D[10];
	public static int armazena;
	float porcentagem;
	public static int delay;
	int alet, contarImagem;
	bool destrava;
	
	void Update(){
		if(rodarRoleta5.tempo == 0){
			for(int i = 0; i <= travaImagem.Length -1 ; i++){
				travaImagem[i] = 0;
			}
			contarImagem = 0;
		}

	}
	
	void OnTriggerEnter(Collider slot){
		if(roletaImag1.delay > 0){
			destrava = false;
			if(rodarRoleta1.tempo != 0 && contarImagem <= 16){
				contarImagem++;
				if(layout.inversao == 0){
					while(!destrava){
						porcentagem = Random.Range(0 , 51);		
						
						//print ("comer");
						//abobora
						if(porcentagem <= 0 && travaImagem[6] < 1){//0
							travaImagem[6] +=1;
							alet = 6;
						}
						
						//capeta
						if(porcentagem > 0 && porcentagem <= 1 && travaImagem[7] < 1){//1
							travaImagem[7] +=1;
							alet = 7;
							destrava = true;
						}
						
						//magico
						if(porcentagem > 1 && porcentagem <= 3 && travaImagem[8] < 1){//2-3-4
							travaImagem[8] +=1;
							alet = 8;
							destrava = true;
						}
						
						//bruxa vassoura
						if(porcentagem > 3 && porcentagem <= 7 && travaImagem[4] < 1){//4-5-6-7
							travaImagem[4] +=1;
							alet = 4;
							destrava = true;
						}
						
						//panela
						if(porcentagem > 7 && porcentagem <= 10 && travaImagem[9] < 1 ){//9-10-11
							travaImagem[9] +=1;
							alet = 9;
							destrava = true;
						}
						
						//espantalho
						if(porcentagem > 10 && porcentagem <= 14 && travaImagem[0] < 2){//12-13-14-15
							travaImagem[0] +=1;
							alet = 0;
							destrava = true;
						}
						
						//witch
						if(porcentagem > 14 && porcentagem <= 17 && travaImagem[1] < 2){//15-16-17
							travaImagem[1] +=1;
							alet = 1;
							destrava = true;
						}
						
						//vampiro
						if(porcentagem > 17 && porcentagem <= 24 && travaImagem[2] < 2){//18-19-20-21-22-24
							travaImagem[2] +=1;
							alet = 2;
							destrava = true;
						}
						
						//frank
						if(porcentagem > 24 && porcentagem <= 35 && travaImagem[5] < 4){//26-27-28-29-30-31-32-33-34-35
							travaImagem[5] +=1;
							alet = 5;
							destrava = true;
						}
						
						//fantasma
						if(porcentagem > 35 && travaImagem[3] < 5){//-35-50
							travaImagem[3] +=1;
							alet = 3;
							destrava = true;
						}	
					}
				}
				else{
					while(!destrava){
						porcentagem = Random.Range(0 , 51);		
						
						//print ("comer");
						//abobora
						if(porcentagem <= 0 && travaImagem[6] < 1){//0
							travaImagem[6] +=1;
							alet = 6;
						}
						
						//capeta
						if(porcentagem > 0 && porcentagem <= 1 && travaImagem[7] < 1){//1
							travaImagem[7] +=1;
							alet = 6;
							destrava = true;
						}
						
						//magico
						if(porcentagem > 1 && porcentagem <= 3 && travaImagem[8] < 1){//2-3-4
							travaImagem[8] +=1;
							alet = 8;
							destrava = true;
						}
						
						//bruxa vassoura
						if(porcentagem > 3 && porcentagem <= 7 && travaImagem[4] < 1){//4-5-6-7
							travaImagem[4] +=1;
							alet = 4;
							destrava = true;
						}
						
						//panela
						if(porcentagem > 7 && porcentagem <= 10 && travaImagem[9] < 1 ){//9-10-11
							travaImagem[9] +=1;
							alet = 3;
							destrava = true;
						}
						
						//espantalho
						if(porcentagem > 10 && porcentagem <= 14 && travaImagem[0] < 2){//12-13-14-15
							travaImagem[0] +=1;
							alet = 0;
							destrava = true;
						}
						
						//witch
						if(porcentagem > 14 && porcentagem <= 17 && travaImagem[1] < 2){//15-16-17
							travaImagem[1] +=1;
							alet = 1;
							destrava = true;
						}
						
						//vampiro
						if(porcentagem > 17 && porcentagem <= 24 && travaImagem[2] < 2){//18-19-20-21-22-24
							travaImagem[2] +=1;
							alet = 2;
							destrava = true;
						}
						
						//frank
						if(porcentagem > 24 && porcentagem <= 35 && travaImagem[5] < 4){//26-27-28-29-30-31-32-33-34-35
							travaImagem[5] +=1;
							alet = 5;
							destrava = true;
						}
						
						//fantasma
						if(porcentagem > 35 && travaImagem[3] < 5){//-35-50
							travaImagem[3] +=1;
							alet = 3;
							destrava = true;
						}	
					}
				}


				slot.gameObject.renderer.material.mainTexture = img[alet];
			}
		}
	}
}
