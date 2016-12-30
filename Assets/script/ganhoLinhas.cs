using UnityEngine;
using System;
using System.Collections;

public class ganhoLinhas : MonoBehaviour {

	public static int linhapremiacao = 0;
	public static bool valendo = false, zera = false, primeiraRoda = true, rodadaGratis;
	public static int salvapremio = 0;
	public static int multiplicador;
	public static string figura;
	public static int[] bonus = new int[7];
	public static int[] configuracao = new int[11];

	public static void premio(){
		if(valendo){
			// 3 acertos direita ou esquerda
			if(linhapremiacao == 1){
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 200 * bancoDados.aposta;
					configuracao[5] += 200 * bancoDados.aposta;
				}
				//fank stain
				if(figura == "slot06c (UnityEngine.Texture2D)"){
					bancoDados.premio += 5 * bancoDados.aposta;
					configuracao[6] += 5 * bancoDados.aposta;				
				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					bancoDados.premio += 300 * bancoDados.aposta;
					configuracao[7] += 300 * bancoDados.aposta;
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					bancoDados.premio += 500 * bancoDados.aposta;
					configuracao[8] += 500 * bancoDados.aposta;
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 250 * bancoDados.aposta;
					configuracao[9] += 250 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bancoDados.premio += 150 * bancoDados.aposta;
					configuracao[10] += 150 * bancoDados.aposta;
				}
				//espantalho 7 free spin
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					bancoDados.premio += 10 * bancoDados.aposta;
					configuracao[1] += 10 * bancoDados.aposta;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					bancoDados.premio += 7 * bancoDados.aposta;
					configuracao[2] += 7 * bancoDados.aposta;
				}
				//vampiro
				if(figura == "slot03c (UnityEngine.Texture2D)"){
					bancoDados.premio += 5 * bancoDados.aposta;
					configuracao[3] += 5 * bancoDados.aposta;
				}

			}

			// 3 acertos em qualquer posicao
			if(linhapremiacao == 2){
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 10 * bancoDados.aposta;
					configuracao[5] += 10 * bancoDados.aposta;
				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					bancoDados.premio += 200 * bancoDados.aposta;
					configuracao[7] += 200 * bancoDados.aposta;
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					bancoDados.premio += 250 * bancoDados.aposta;
					configuracao[8] += 250 * bancoDados.aposta;
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 10 * bancoDados.aposta;
					configuracao[9] += 10 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bancoDados.premio += 150 * bancoDados.aposta;
					configuracao[10] += 150 * bancoDados.aposta;
				}
				//espantalho
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					bancoDados.premio += 10 * bancoDados.aposta;
					configuracao[1] += 10 * bancoDados.aposta;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					bancoDados.premio += 3 * bancoDados.aposta;
					configuracao[2] += 3 * bancoDados.aposta;
				}
			}

			// 3 acertos em pe
			if(linhapremiacao == 3){
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 300 * bancoDados.aposta;
					configuracao[5] += 300 * bancoDados.aposta;
				}
				//fank stain
				if(figura == "slot06c (UnityEngine.Texture2D)"){
					bancoDados.premio += 20 * bancoDados.aposta;
					configuracao[6] += 20 * bancoDados.aposta;

				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					bancoDados.premio += 300 * bancoDados.aposta;
					configuracao[7] += 300 * bancoDados.aposta;
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					bancoDados.premio += 250 * bancoDados.aposta;
					configuracao[8] += 250 * bancoDados.aposta;
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 200 * bancoDados.aposta;
					configuracao[9] += 200 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bancoDados.premio += 100 * bancoDados.aposta;
					configuracao[10] += 100 * bancoDados.aposta;
				}
				//espantalho free spin
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					rodadaGratis = true;
					bonus[5] += 6;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					//bingo
					//bonus[4] += 1; pequeno teste
					bancoDados.premio += 400 * bancoDados.aposta;
					configuracao[2] += 400 * bancoDados.aposta;

				}
				//vampiro
				if(figura == "slot03c (UnityEngine.Texture2D)"){
					//bingo
					bancoDados.premio += 200 * bancoDados.aposta;
					configuracao[3] += 200 * bancoDados.aposta;

				}
				//fantasma
				if(figura == "slot04c (UnityEngine.Texture2D)"){
					bancoDados.premio += 20 * bancoDados.aposta;
					configuracao[4] += 20 * bancoDados.aposta;

				}

			}



			//valendo 4 acertos
//--------------------------------------------------------
			// 4 acertos
			if(linhapremiacao == 10){
				//fantasma
				if(figura == "slot04c (UnityEngine.Texture2D)"){
					bancoDados.premio += 2 * bancoDados.aposta;
					configuracao[4] +=  2 * bancoDados.aposta;

				}
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 600 * bancoDados.aposta;
					configuracao[5] += 600 * bancoDados.aposta;
				}
				//fank stain
				if(figura == "slot06c (UnityEngine.Texture2D)"){
					bancoDados.premio += 7 * bancoDados.aposta;
					configuracao[6] += 7 * bancoDados.aposta;
				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					bancoDados.premio += 1000 * bancoDados.aposta;
					configuracao[7] += 1000 * bancoDados.aposta;
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					bancoDados.premio += 1000 * bancoDados.aposta;
					configuracao[8] +=  1000 * bancoDados.aposta;
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 500 * bancoDados.aposta;
					configuracao[9] += 500 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bancoDados.premio += 300 * bancoDados.aposta;
					configuracao[10] += 300 * bancoDados.aposta;
				}
				//espantalho
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					bancoDados.premio += 50 * bancoDados.aposta;
					configuracao[1] += 50 * bancoDados.aposta;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					bancoDados.premio += 100 * bancoDados.aposta;
					configuracao[2] += 100 * bancoDados.aposta;
				}
				//vampiro
				if(figura == "slot03c (UnityEngine.Texture2D)"){
					bancoDados.premio += 30 * bancoDados.aposta;
					configuracao[3] += 30 * bancoDados.aposta;
				}
				
			}
			
			// 4 acertos
			if(linhapremiacao == 20){
				//fantasma
				if(figura == "slot04c (UnityEngine.Texture2D)"){
					bancoDados.premio += 2 * bancoDados.aposta;
					configuracao[4] +=  2 * bancoDados.aposta;

				}
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 600 * bancoDados.aposta;
					configuracao[5] += 600 * bancoDados.aposta;
				}
				//fank stain
				if(figura == "slot06c (UnityEngine.Texture2D)"){
					bancoDados.premio += 7 * bancoDados.aposta;
					configuracao[6] += 7 * bancoDados.aposta;
				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					bancoDados.premio += 1000 * bancoDados.aposta;
					configuracao[7] += 1000 * bancoDados.aposta;
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					bancoDados.premio += 1000 * bancoDados.aposta;
					configuracao[8] +=  1000 * bancoDados.aposta;
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 500 * bancoDados.aposta;
					configuracao[9] += 500 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bancoDados.premio += 300 * bancoDados.aposta;
					configuracao[10] += 500 * bancoDados.aposta;
				}
				//espantalho
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					bancoDados.premio += 50 * bancoDados.aposta;
					configuracao[1] += 50 * bancoDados.aposta;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					bancoDados.premio += 100 * bancoDados.aposta;
					configuracao[2] += 100 * bancoDados.aposta;
				}
				//vampiro
				if(figura == "slot03c (UnityEngine.Texture2D)"){
					bancoDados.premio += 30 * bancoDados.aposta;
					configuracao[3] += 30 * bancoDados.aposta;
				}
				
			}



			//apartir daqui 5 acertos
//---------------------------------------------------------
			// 5 acertos
			if(linhapremiacao == 100){
				//fantasma
				if(figura == "slot04c (UnityEngine.Texture2D)"){
				
					bancoDados.premio += 30 * bancoDados.aposta;
					configuracao[4] += 30 * bancoDados.aposta;
				}
				//bruxa vassoura
				if(figura == "slot05c (UnityEngine.Texture2D)"){
					bancoDados.premio += 2000 * bancoDados.aposta;
					configuracao[5] += 2000 * bancoDados.aposta;
				}
				//fank stain
				if(figura == "slot06c (UnityEngine.Texture2D)"){
					bancoDados.premio += 30 * bancoDados.aposta;
					configuracao[6] += 30 * bancoDados.aposta;

				}
				//abobora
				if(figura == "slot07c (UnityEngine.Texture2D)"){
					configuracao[7] += 2000 * bancoDados.aposta;
					if((layout.tecla*bancoDados.aposta*bancoDados.valorAposta) < 50){
						bancoDados.premio += 2000 * bancoDados.aposta;
					}
					else{
						bancoDados.premio += ( Convert.ToInt16(bancoDados.lerPulso()) * ( Convert.ToInt16(bancoDados.lerAcumulado1()) ));
						bancoDados.ConfiguraAcumuladoM1 = bancoDados.lerMINIMO1();
						bancoDados.confAcumulado1();
					}
				}
				//capeta
				if(figura == "slot08c (UnityEngine.Texture2D)"){
					configuracao[8] += 2000 * bancoDados.aposta;
					if((layout.tecla*bancoDados.aposta*bancoDados.valorAposta) < 50){
						bancoDados.premio += 2000 * bancoDados.aposta;
					}
					else{
						bancoDados.premio += ( Convert.ToInt16(bancoDados.lerPulso()) * ( Convert.ToInt16(bancoDados.lerAcumulado1()) ));
						bancoDados.ConfiguraAcumuladoM1 = bancoDados.lerMINIMO2();
						bancoDados.confAcumulado2();
					}
				}
				//magico
				if(figura == "slot09c (UnityEngine.Texture2D)"){
					bancoDados.premio += 2000 * bancoDados.aposta;
					configuracao[9] += 2000 * bancoDados.aposta;
				}
				//panela
				if(figura == "slot10c (UnityEngine.Texture2D)"){
					bonus[3] += 450 * bancoDados.aposta;
					configuracao[10] += 450 * bancoDados.aposta;
				}
				//espantalho
				if(figura == "slot01c (UnityEngine.Texture2D)"){
					bancoDados.premio += 200 * bancoDados.aposta;
					configuracao[1] +=  200 * bancoDados.aposta;
				}
				//witch
				if(figura == "slot02c (UnityEngine.Texture2D)"){
					bancoDados.premio += 150 * bancoDados.aposta;
					configuracao[2] += 150 * bancoDados.aposta;
				}
				//vampiro
				if(figura == "slot03c (UnityEngine.Texture2D)"){
					bancoDados.premio += 75 * bancoDados.aposta;
					configuracao[3] += 75 * bancoDados.aposta;
				}
				
			}
			

		}
	}

}