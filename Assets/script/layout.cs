using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class layout : MonoBehaviour {
	public static int TESTEdeRODADAS;
	public static int tecla= 1, inversao;
	int cont = 0;
	int recebeCredito;
	public static bool mostratecla = false, auto = false, autoTeste = false;
	public Texture2D gato, credito, aposta, premio, balao, balaoAposta, morcego;
	public GUIStyle estilo, estilo2, estilo3, estilo4, estilo5;
	public Texture2D carregando;
	bool carregandoBool, atrasoGAnho, vozBonus; 
	public AudioClip[] bonus = new AudioClip[9];
	public AudioClip dinheiroSom;
	public static int inteligencia;


	// Use this for initialization
	void Start () {
		vozBonus =false;
		if(ganhoLinhas.primeiraRoda){
			ganhoLinhas.primeiraRoda = false;
			roletaImag1.delay = 2;
			rodarRoleta1.tempo = 800;
			rodarRoleta2.tempo =  800;
			rodarRoleta3.tempo =  800;
			rodarRoleta4.tempo = 800;
			rodarRoleta5.tempo = 800;
			ganhoLinhas.valendo = false;		//condicao para validar premiaçao 1 vez a cada jogada
			ganhoLinhas.zera = true;
			mostratecla = false; 			//deixa as linhas invisiveis
			cont = 15;
		}


	}
	
	// Update is called once per frame
	void Update () {
		//fica verificando acada frame se tem creditos
		bancoDados.salvaCredito();
		if(Input.GetKeyDown(KeyCode.Z)){
			ganhoLinhas.bonus[5] += 100; 
		}
		if(Input.GetKeyDown(KeyCode.X)){

			for(int i = 1; i <= ganhoLinhas.configuracao.Length-1;i++){

				switch(i){
				case 1:
					print("Espantalho = " +ganhoLinhas.configuracao[i]);
					break;
				case 2:
					print("Witch = " +ganhoLinhas.configuracao[i]);
					break;
				case 3:
					print("Vampiro = " +ganhoLinhas.configuracao[i]);
					break;
				case 4:
					print("Fantasma = " +ganhoLinhas.configuracao[i]);
					break;
				case 5:
					print("Bruxa Vassoura = " +ganhoLinhas.configuracao[i]);
					break;
				case 6:
					print("Monstro = " +ganhoLinhas.configuracao[i]);
					break;
				case 7:
					print("Abobora = " +ganhoLinhas.configuracao[i]);
					break;
				case 8:
					print("Capeta = " +ganhoLinhas.configuracao[i]);
					break;
				case 9:
					print("Magico = " +ganhoLinhas.configuracao[i]);
					break;
				case 10:
					print("Panela = " +ganhoLinhas.configuracao[i]);
					break;
				}
			}
		}
		if(bancoDados.premio > (4*layout.tecla*bancoDados.aposta*bancoDados.valorAposta) ){
			gameObject.transform.position = new Vector3(Random.Range(-0.02f,0.02f),1,-10.5f);                                                      
		}
		//impede que as linhas sejam selecionadas enquanto a roleta gira
		//if(rodarRoleta5.tempo != 0) print ("inteligencia = " + inteligencia);
		if(rodarRoleta5.tempo == 0){
			inversao = Random.Range(0,2);
			//configuracao de porcentagem
			//aqui a maquina decide se paga ou come
			if( (( bancoDados.lerEntradaTotal()*bancoDados.lerPorcentagem()) - bancoDados.lerSaida()) <= 0){
				//come credito
				inteligencia = 1;
				
			}
			else if( (( bancoDados.lerEntradaTotal()*bancoDados.lerPorcentagem()) - bancoDados.lerSaida()) >  5000){
				//pagar
				if( (( bancoDados.lerEntradaTotal()*bancoDados.lerPorcentagem()) - bancoDados.lerSaida()) < bancoDados.carregaCredito()){
					//comer
					inteligencia = 1;
				}
				else if( (tecla*bancoDados.aposta*bancoDados.valorAposta) > 50 ){
					inteligencia = Random.Range(0,8);
				}
				else if( (tecla*bancoDados.aposta*bancoDados.valorAposta) >= 50 ){
					inteligencia = Random.Range(0,11);
				}
				else{
					inteligencia = Random.Range(0,21);
				}
			}
			// segunda logica caso tenha dinheiro na maquina 
			else if( (( bancoDados.lerEntradaTotal()*bancoDados.lerPorcentagem()) - bancoDados.lerSaida()) < bancoDados.carregaCredito()){
				//pagar
				inteligencia = 1;
				
			}
			else{
				//pagar
				inteligencia = 1;
			}

			//BOTAO Y ou botao linha  
			if( Input.GetButtonDown("Y") && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;	
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla++;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla++;
					}
				}
				//se clicar em mais teclas que 25 ele volta pra 1°
				if(tecla > 25){
					tecla = 1;
				}
			}

			//Tecla J 5 linhas
			if( Input.GetButtonDown("J") && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla = 5;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla = 5;
					}
				}
			}

			//Tecla h linhas
			if( Input.GetButtonDown("H") && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla = 9;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla = 9;
					}
				}
			}

			//Tecla m linhas
			if( Input.GetButtonDown("M") && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla = 15;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla = 15;
					}
				}
			}

			//Tecla n linhas
			if( Input.GetButtonDown("N") && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla = 20;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla = 20;
					}
				}
			}

			//Tecla s 25 linhas
			if( Input.GetKeyDown(KeyCode.F) && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0){
				ganhoLinhas.valendo = false;
				audio.Play();
				//essa condiçao e pra o começo do jogo quando nem uma tecla foi apertada
				if(tecla < 1){
					mostratecla = true;
					tecla = 25;
				}
				else{
					// aqui no caso ele ja escolheu ex 5 linhas e jogou e agora quer escolher de novo
					//primeiro vai abilitar pra depois na segunda apertada vai add + linhas
					if(!mostratecla){
						mostratecla = true;
					}
					else{
						tecla = 25;
					}
				}
			}

			//botão aposta
			if( Input.GetButtonDown("G") && !auto && ganhoLinhas.bonus[0] == 0 && ganhoLinhas.bonus[1] == 0 && ganhoLinhas.bonus[2] == 0 && ganhoLinhas.bonus[3] == 0 && ganhoLinhas.bonus[4] == 0 && ganhoLinhas.bonus[5] == 0 && bancoDados.premio == 0 && ganhoLinhas.bonus[6] == 0 ){
				ganhoLinhas.valendo = false;
				bancoDados.aposta++;
				if(bancoDados.aposta > 10){
					bancoDados.aposta = 1;
				}
			}
			if(Input.GetKeyDown(KeyCode.R)){
				if(bancoDados.carregaCredito() != 0){
					Application.LoadLevel("pagar");
				}
			}
			if(Input.GetKeyDown(KeyCode.Keypad4) || Input.GetButtonDown("quatro")) Application.LoadLevel("configuracao");


			carregandoBool = false;
			/*condiçao para salvar premio ganho e somar aos creditos nao pode jogar enquanto nao somar todo
			o valor ganho.*/
			if(bancoDados.premio > 0 || ganhoLinhas.bonus[0] != 0 || ganhoLinhas.bonus[1] != 0 || ganhoLinhas.bonus[2] != 0 || ganhoLinhas.bonus[3] != 0 || ganhoLinhas.bonus[4] != 0 || ganhoLinhas.bonus[6] != 0){
				if(ganhoLinhas.zera){
					bancoDados.ganho = 0;
					ganhoLinhas.zera = false;
				}

					if(!atrasoGAnho){
						atrasoGAnho = true;
						contandoGanho();
					}
				

				//StartCoroutine(ganhoLinhas.chamaPremio());//erro testar -----------------------------------------
			
			}
			// botao jogar zera todas as variaveis da roleta
			else{
				if(cont > 0){
					cont--;
				}
				else{
					if(Input.GetButton("B")){
						if((tecla * bancoDados.aposta) <= bancoDados.carregaCredito() ){
							if( bancoDados.lerAcumulado1() < bancoDados.lerMAXIMO1() && (tecla*bancoDados.aposta*bancoDados.valorAposta) >= 50) bancoDados.acumulado1();
							if( bancoDados.lerAcumulado2() < bancoDados.lerMAXIMO2() && (tecla*bancoDados.aposta*bancoDados.valorAposta) >= 50) bancoDados.acumulado2();
							roletaImag1.delay = 2;
							bancoDados.entradaPorcentagem();
							jogaMoedas.ativa = false;
							rodarRoleta1.tempo = -80;
							rodarRoleta2.tempo = -82;
							rodarRoleta3.tempo = -84;
							rodarRoleta4.tempo = -86;
							rodarRoleta5.tempo = -90;
							ganhoLinhas.valendo = true;		//condicao para validar premiaçao 1 vez a cada jogada
							ganhoLinhas.zera = true;
							mostratecla = false; 			//deixa as linhas invisiveis
							bancoDados.creditos -= bancoDados.aposta * tecla * bancoDados.valorAposta;
							cont = 15;
						}
					}
					if(ganhoLinhas.bonus[5] > 0){
						if(ganhoLinhas.rodadaGratis){
							ganhoLinhas.rodadaGratis = false;
							audio.PlayOneShot(bonus[7]);
						}
							jogaMoedas.ativa = false;
							roletaImag1.delay = 2;
							rodarRoleta1.tempo = -80;
							rodarRoleta2.tempo = -82;
							rodarRoleta3.tempo = -84;
							rodarRoleta4.tempo = -86;
							rodarRoleta5.tempo = -90;
							ganhoLinhas.valendo = true;		//condicao para validar premiaçao 1 vez a cada jogada
							ganhoLinhas.zera = true;
							mostratecla = false; 			//deixa as linhas invisiveis
							ganhoLinhas.bonus[5] -= 1;
							cont = 15;
					}
					else if(auto){ // automatico
						if((tecla * bancoDados.aposta) <= bancoDados.carregaCredito() ){
							if( bancoDados.lerAcumulado1() < bancoDados.lerMAXIMO1() && (tecla*bancoDados.aposta*bancoDados.valorAposta) >= 50) bancoDados.acumulado1();
							if( bancoDados.lerAcumulado2() < bancoDados.lerMAXIMO2() && (tecla*bancoDados.aposta*bancoDados.valorAposta) >= 50) bancoDados.acumulado2();
							bancoDados.entradaPorcentagem();
							roletaImag1.delay = 2;
							jogaMoedas.ativa = false;
							TESTEdeRODADAS++;
							rodarRoleta1.tempo = -80;
							rodarRoleta2.tempo = -82;
							rodarRoleta3.tempo = -84;
							rodarRoleta4.tempo = -86;
							rodarRoleta5.tempo = -90;
							ganhoLinhas.valendo = true;		//condicao para validar premiaçao 1 vez a cada jogada
							ganhoLinhas.zera = true;
							mostratecla = false; 			//deixa as linhas invisiveis
							bancoDados.creditos -= bancoDados.aposta * tecla * bancoDados.valorAposta;
							autoTeste = false;
							cont = 60;
						}
					}

				}
			}
	

			
		}// fim do teste de parada de roleta

		//entrada de dinheiro fica fora da condiçao de roleta parada pois assim o jogador
		//pode colocar dinheiro com o jogo rolando
		if( Input.GetButtonDown("P") || Input.GetButton("P")){
			bancoDados.creditos += bancoDados.lerPulso();
			bancoDados.EntradaTotal();

		}

		//botao para ativar automatico
		if(Input.GetKeyDown(KeyCode.V)){
			auto = !auto;
			cont = 60;
		}
		if(bancoDados.carregaCredito() <= 0){
			auto = false;
		}

	}

	void chamaBonus(){
		for(int i = 0; i <= ganhoLinhas.bonus.Length - 1;i++){
			if(ganhoLinhas.bonus[i] != 0){
				switch(i){
				case 0:
					carregandoBool = false;
					Application.LoadLevel("corrida");
					break;
				case 1:
					carregandoBool = false;
					Application.LoadLevel("bau");
					break;
				case 2:
					carregandoBool = false;
					Application.LoadLevel("dados");
					break;
				case 3:
					carregandoBool = false;
					Application.LoadLevel("bonusPanela");
					break;
				case 4:
					carregandoBool = false;
					Application.LoadLevel("bingo");
					break;
				case 6:
					carregandoBool = false;
					Application.LoadLevel("bau2Vamp");
					break;
				}
			}
		}
	}

	void contandoGanho(){
		if(bancoDados.premio >0  && ganhoLinhas.bonus[0] == 0 && ganhoLinhas.bonus[1] == 0 && ganhoLinhas.bonus[2] == 0 && ganhoLinhas.bonus[3] == 0 && ganhoLinhas.bonus[4] == 0){
			while(bancoDados.premio > 0){
				bancoDados.saidaPorcentagem();
				bancoDados.creditos += bancoDados.premio;
				bancoDados.ganho += bancoDados.premio;
				bancoDados.premio = 0;
				//audio.PlayOneShot(dinheiroSom,0.25f);
				//	if(bancoDados.premio == 0) bancoDados.saida();
			}


		}
		if(bancoDados.premio <= 0){
			atrasoGAnho = false;
		//	ganhoLinhas.valendo = false;// linhas para nao ficar somando a premiaçao infinitamente
		}
	}
		
		
	void OnGUI(){

		if(carregandoBool) {
			GUI.DrawTexture(new Rect(0,0,Screen.width+1,Screen.height+1),carregando);
		}
		else{
			//Screen.height/120 = 5 px
			//creditos
			GUI.DrawTexture(new Rect(Screen.width/120,Screen.height/85.714f,Screen.width/5.714281F,Screen.height/15),credito);
			GUI.DrawTexture(new Rect(Screen.width/5.517239F,Screen.height/60,Screen.width/5,Screen.height/12),balao);
			GUI.Label(new Rect(Screen.width/5.161291F,Screen.height/35.29458f,250,50),"" + bancoDados.carregaCredito(),estilo);

			//Screen.height/120 = 5 px
			//premio
			GUI.DrawTexture(new Rect(Screen.width/2.580645f,Screen.height/85.714f,Screen.width/5.714281F,Screen.height/15),premio);
			GUI.DrawTexture(new Rect(Screen.width/1.8F,Screen.height/60,Screen.width/5,Screen.height/12),balao);
			GUI.Label(new Rect(Screen.width/1.73913F,Screen.height/35.29458f,250,50),"" + bancoDados.premio,estilo);

			//Screen.height/120 = 5 px
			//aposta e linhas 
			// botao aposta 120width
			GUI.DrawTexture(new Rect(Screen.width/1.311475f,Screen.height/85.714f,Screen.width/8.0F,Screen.height/15),aposta);
			GUI.DrawTexture(new Rect(Screen.width/1.134752f,Screen.height/60,Screen.width - (Screen.width- 90),Screen.height/12),balaoAposta);
			GUI.Label(new Rect(Screen.width/1.111111f,Screen.height/35.29458f,250,50),"" + (tecla*bancoDados.aposta*bancoDados.valorAposta),estilo);
			//aposta e morcego
			GUI.DrawTexture(new Rect(Screen.width/1.311476f,Screen.height/13.33337f,morcego.width/1.4f,morcego.height/1.2f),morcego);
			GUI.Label(new Rect(Screen.width/1.230779f,Screen.height/12.00007f,250,50),"" + bancoDados.aposta, estilo2);
			//ultimo valor pago
			GUI.Label(new Rect(Screen.width/20,Screen.height/10.0007f,200,25),"Pago: " + bancoDados.ganho, estilo5);

			//acumulado 2
			GUI.DrawTexture(new Rect(Screen.width/80,Screen.height/1.20f,Screen.width/3.8f,Screen.height/12),balao);
			GUILayout.BeginArea(new Rect(Screen.width/80,Screen.height/1.18f,Screen.width/3.8f,Screen.height/12) );
			GUILayout.Label("R$ " + string.Format("{0:0.00}",bancoDados.lerAcumulado2()) ,estilo4);
			GUILayout.EndArea();
			
			//acumulado 1
			GUI.DrawTexture(new Rect(Screen.width/1.4f,Screen.height/1.20f,Screen.width/3.8f,Screen.height/12),balao);
			GUILayout.BeginArea(new Rect(Screen.width/1.4f,Screen.height/1.18f,Screen.width/3.8f,Screen.height/12) );
			GUILayout.Label("R$ " + string.Format("{0:0.00}",bancoDados.lerAcumulado1()) ,estilo4);
			GUILayout.EndArea();

		}
			//automatico
			//ganhou premio
		//*************************************
		GUILayout.BeginArea(new Rect(Screen.width/80,Screen.height/1.2f,Screen.width-Screen.width/80,50));
		GUILayout.BeginHorizontal("");
		GUILayout.Label("Radada: "+ TESTEdeRODADAS, estilo4);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//***********************************
		GUILayout.BeginArea(new Rect(Screen.width/80,Screen.height/7.5f,Screen.width-Screen.width/80,50));
		if(bancoDados.premio > 0){
			GUILayout.BeginHorizontal("");
			GUILayout.Label("GANHOU PREMIO", estilo4);
			GUILayout.EndHorizontal();
		}
		else if(ganhoLinhas.bonus[5] > 0){
			GUILayout.BeginHorizontal("");
			GUILayout.Label("RODADA GRATIS "+ganhoLinhas.bonus[5], estilo4);
			GUILayout.EndHorizontal();
		}
		else if(auto){
			GUILayout.BeginHorizontal("");
			GUILayout.Label("AUTOMATICO", estilo4);
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea();





		if(bancoDados.carregaCredito() <= 0){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),gato);
		}

	}

}
