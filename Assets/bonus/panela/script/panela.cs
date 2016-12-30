using UnityEngine;
using System.Collections;

public class panela : MonoBehaviour {
	public AudioClip[] riso = new AudioClip[4];
	public AudioClip audioEscolhe;
	public Texture2D[] img = new Texture2D[19];
	public Texture2D background, lua; 
	public static int tecla;
	public static int cont, posicao = Screen.width, tempo = 0;
	public static bool bonusPosibilidade = true;
	bool[] liberaBonus = new bool[5];
	bool bonusMaximo = false,mostraBonus, travaTecla, passaTela, darRisada, travarFrame;
	int  escolheBonus = 0, armazenaValorBonus;
	int[] B = new int[5];
	public GUIStyle estilo,estilo2;
	public static int granaLivre , multiplicador, valorGanho;// essa e a variavel que vai receber o que a maquina pode pagar

	// Use this for initialization
	void Start () {
		multiplicador = ganhoLinhas.bonus[3];
		darRisada = travarFrame = true;
		tecla = cont = tempo =0;
		posicao = Screen.width;
		escolheBonus = 0;
		armazenaValorBonus = 0;
		bonusMaximo = mostraBonus = travaTecla = passaTela = false;
		bonusPosibilidade = true;
		granaLivre = 1000;
		for(int i = 0; i<= 4;i++){
			liberaBonus[i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Y") && !travaTecla){
			travaTecla = true;
			tecla = 1;
			audio.PlayOneShot(audioEscolhe, 0.7F);
			anima();

		}
		if(Input.GetButtonDown("J")&& !travaTecla){
			travaTecla = true;
			tecla = 2;
			audio.PlayOneShot(audioEscolhe, 0.7F);
			anima();
		}
		if(Input.GetButtonDown("H")&& !travaTecla){
			travaTecla = true;
			tecla = 3;
			audio.PlayOneShot(audioEscolhe, 0.7F);
			anima();
		}
		if(Input.GetButtonDown("M")&& !travaTecla){
			travaTecla = true;
			tecla = 4;
			audio.PlayOneShot(audioEscolhe, 0.7F);
			anima();
		}
		if(Input.GetButtonDown("N")&& !travaTecla){
			travaTecla = true;
			tecla = 5;
			audio.PlayOneShot(audioEscolhe, 0.7F);
			anima();
		}

		//se alguma tecla for apertada
		if(tecla != 0){
			//entra aqui caso o banco nao tenha dinheiro para pagar 500 ou +
			if((bancoDados.lerEntradaTotal()* bancoDados.lerPorcentagem() - bancoDados.lerSaida()) < 500*multiplicador*bancoDados.aposta){
				//escolhe uma imagem aleatoria e ve se esta livre
				escolheBonus = Random.Range(14,18);
				//no caso aqui seleciona a imagem que deixa escolher
				if(!bonusMaximo){
					bonusMaximo = true;
					liberaBonus[escolheBonus-14] = false;
					armazenaValorBonus = escolheBonus;
					B[(tecla-1)] = escolheBonus;
				}
				else{
					for(int i = 0; i <= 4;i++){
						if(B[i] == 0){
							escolheBonus = Random.Range(14,19);
							if(liberaBonus[escolheBonus-14]){
								liberaBonus[escolheBonus-14] = false;
								B[i] = escolheBonus;
							}
						}
						
					}
					
					
				}				
			
			}
			//caso a maquina tenha dinheiro para pagar o bonus vem pra ca
			else{
				for(int i = 0; i <= 4;i++){
					if(!bonusMaximo){
						escolheBonus = Random.Range(14,19);
						bonusMaximo = true;
						liberaBonus[escolheBonus-14] = false;
						armazenaValorBonus = escolheBonus;
						B[(tecla-1)] = escolheBonus;
					}
					else if(B[i] == 0){
						escolheBonus = Random.Range(14,19);
						if(liberaBonus[escolheBonus-14]){
							liberaBonus[escolheBonus-14] = false;
							B[i] = escolheBonus;
						}
					}
					
				}
			}
		}
			

		
	}
	
	void OnGUI(){
		//lua
		GUI.DrawTexture(new Rect(posicao,0,Screen.width,Screen.height),lua);

		if(posicao <= -tempo){
			if(posicao <= -Screen.width){
				posicao = Screen.width;
				tempo = 0;
			}
			else{
				StartCoroutine(atraso2());
			}
		}
		else{
			posicao--;
		}

		//background
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background);
		//loop panela fogo
		if(panelaVariaveis.tela2){
			if(tecla != 1){
				GUI.DrawTexture(new Rect(Screen.width/80,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			}
			if(tecla != 2){
			GUI.DrawTexture(new Rect(Screen.width/4.705882f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			}
			if(tecla != 3){
			GUI.DrawTexture(new Rect(Screen.width/2.424243f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			}
			if(tecla != 4){
			GUI.DrawTexture(new Rect(Screen.width/1.632656f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			}
			if(tecla != 5){
			GUI.DrawTexture(new Rect(Screen.width/1.230769f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			}
		}
		else{
			GUI.DrawTexture(new Rect(Screen.width/80,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			GUI.DrawTexture(new Rect(Screen.width/4.705882f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			GUI.DrawTexture(new Rect(Screen.width/2.424243f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			GUI.DrawTexture(new Rect(Screen.width/1.632656f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
			GUI.DrawTexture(new Rect(Screen.width/1.230769f,Screen.height - Screen.height/4,img[0].width,img[0].height),img[Random.Range(0,5)]);
		}


		switch(tecla){
		case 1:
			GUI.DrawTexture(new Rect(Screen.width/80,Screen.height/3,img[12].width,img[12].height),img[4 + cont]);
			break;
		case 2:
			GUI.DrawTexture(new Rect(Screen.width/4.705882f,Screen.height/3,img[12].width,img[12].height),img[4 + cont]);
			break;
		case 3:
			GUI.DrawTexture(new Rect(Screen.width/2.424243f,Screen.height/3,img[12].width,img[12].height),img[4 + cont]);
			break;
		case 4:
			GUI.DrawTexture(new Rect(Screen.width/1.632656f,Screen.height/3,img[12].width,img[12].height),img[4 + cont]);
			break;
		case 5:
			GUI.DrawTexture(new Rect(Screen.width/1.230769f,Screen.height/3,img[12].width,img[12].height),img[4 + cont]);
			break;
		}


		if(cont >= 7){
			switch(tecla){
			case 1:
				GUI.DrawTexture(new Rect(Screen.width/18,Screen.height/1.9f,img[14].width,img[14].height),img[B[0]]);
				if(armazenaValorBonus == 18 && darRisada){
					darRisada = false;
					audio.PlayOneShot(riso[Random.Range(0,4)], 1);
				}
				break;
			case 2:
				GUI.DrawTexture(new Rect(Screen.width/4,Screen.height/1.9f,img[14].width,img[14].height),img[B[1]]);
				if(armazenaValorBonus == 18 && darRisada){
					darRisada = false;
					audio.PlayOneShot(riso[Random.Range(0,4)], 1);
				}
				break;
			case 3:
				GUI.DrawTexture(new Rect(Screen.width/2.2f,Screen.height/1.9f,img[14].width,img[14].height),img[B[2]]);
				if(armazenaValorBonus == 18 && darRisada){
					darRisada = false;
					audio.PlayOneShot(riso[Random.Range(0,4)], 1);
				}
				break;
			case 4:
				GUI.DrawTexture(new Rect(Screen.width/1.53f,Screen.height/1.9f,img[14].width,img[14].height),img[B[3]]);
				if(armazenaValorBonus == 18 && darRisada){
					darRisada = false;
					audio.PlayOneShot(riso[Random.Range(0,4)], 1);
				}
				break;
			case 5:
				GUI.DrawTexture(new Rect(Screen.width/1.1558f,Screen.height/1.9f,img[14].width,img[14].height),img[B[4]]);
				if(armazenaValorBonus == 18 && darRisada){
					darRisada = false;
					audio.PlayOneShot(riso[Random.Range(0,4)], 1);
				}
				break;
			}
			//isso mostra todos os bonus apos alguns segundos
			if(mostraBonus){
				GUI.DrawTexture(new Rect(Screen.width/18,Screen.height/1.9f,img[14].width,img[14].height),img[B[0]]);
				GUI.DrawTexture(new Rect(Screen.width/4,Screen.height/1.9f,img[14].width,img[14].height),img[B[1]]);
				GUI.DrawTexture(new Rect(Screen.width/2.2f,Screen.height/1.9f,img[14].width,img[14].height),img[B[2]]);
				GUI.DrawTexture(new Rect(Screen.width/1.53f,Screen.height/1.9f,img[14].width,img[14].height),img[B[3]]);
				GUI.DrawTexture(new Rect(Screen.width/1.1558f,Screen.height/1.9f,img[14].width,img[14].height),img[B[4]]);
				passaTela = true;
				atrasoBonus(3);
			}
			else{
				if(panelaVariaveis.tela2){
					if(armazenaValorBonus == 14){
						valorGanho = 100;
					}
					if(armazenaValorBonus == 15){
						valorGanho = 200;
					}
					if(armazenaValorBonus == 16){
						valorGanho = 250;
					}
					if(armazenaValorBonus == 17){
						valorGanho = 500;
					}
					if(armazenaValorBonus == 18){
						valorGanho = 1000;
					}
				}
				else{
					if(armazenaValorBonus == 14){
						valorGanho = 50;
					}
					if(armazenaValorBonus == 15){
						valorGanho = 75;
					}
					if(armazenaValorBonus == 16){
						valorGanho = 100;
					}
					if(armazenaValorBonus == 17){
						valorGanho = 150;
					}
				}
				atrasoBonus(3);
			}
		}


		//layout Creditos
		GUILayout.BeginArea(new Rect(1,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal ("box");
		GUILayout.Label("Creditos: "+bancoDados.carregaCredito(),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout bonus
		GUILayout.BeginArea(new Rect(Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Bonus: "+valorGanho+" X "+multiplicador,estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout premio
		GUILayout.BeginArea(new Rect(Screen.width - Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Premio: "+(valorGanho*multiplicador*bancoDados.aposta + bancoDados.premio),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//instruçoes
		GUILayout.BeginArea(new Rect(1,Screen.height-Screen.height/18,Screen.width,Screen.height/10));
		GUILayout.BeginHorizontal();

		if(!panelaVariaveis.tela2){
			GUILayout.Label("Escolha uma panela tire o bônus ou multiplique seu PRÊMIO em até 150x",estilo2);
		}
		else{
			GUILayout.Label("Escolha uma abobora e multiplique seu bonus em ate 1000 vez",estilo2);
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	
	}
	
	void anima() {
		if(cont >= 9){
			cont = 7;
		}
		switch(tecla){
		case 1:
			cont++;
			atraso();
			break;
		case 2:
			cont++;
			atraso();
			break;
		case 3:
			cont++;
			atraso();
			break;
		case 4:
			cont++;
			atraso();
			break;
		case 5:
			cont++;
			atraso();
			break;
		}
	}
	
	void atraso() {
		Invoke("anima",0.15f);
	}

	IEnumerator atraso2(){

		yield return new WaitForSeconds(5);

		if(tempo <= 0){
			tempo = Screen.width;
		}
	}


	void aguarda(){
		mostraBonus = true;
	}
	//verifica se jogador passa para proximo bonus
	void aguarda2(){
		if(travarFrame){
			travarFrame = false;
			if(armazenaValorBonus == 18 && !panelaVariaveis.tela2){
				panelaVariaveis.tela2 = true;
				Application.LoadLevel("bonusPanela2");
			}
			//caso nao tenha pegado o bonus
			else{
				bancoDados.premio += valorGanho*multiplicador*bancoDados.aposta;
				bancoDados.salvaCredito();
				//bancoDados.saida();
				panelaVariaveis.tela2 = false;
				ganhoLinhas.bonus[3] = valorGanho = 0;
				Application.LoadLevel("game");
			}
		}
	}

	void atrasoBonus(int x){
		if(passaTela){
			Invoke("aguarda2",x);
		}
		else{
			Invoke("aguarda",x);
		}
	}



}
