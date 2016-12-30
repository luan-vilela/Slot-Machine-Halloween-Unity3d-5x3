using UnityEngine;
using System.Collections;

public class sorteaNumeros : MonoBehaviour {
	public static int[] sortea = new int[6];
	public static bool[] livre = new bool[10];
	public Rigidbody2D[] bolasSorteadas = new Rigidbody2D[10];
	int cont = 0, SalvaPontos;
	public static int SomaGanho, premiacao;
	bool bApertado;
	public static bool trava, bingo;
	bool pausado;
	public AudioClip[] pontos = new AudioClip[7];
	public AudioClip moeda;
	public GameObject ajuda;
	public GUIStyle estilo, estilo2;
	int somador;

	// Use this for initialization
	void Start () {
		somador = 0;
		bingo = false;
		SomaGanho = premiacao = SalvaPontos = 0;
		pausado = true;
		trava = false;
		bApertado = false;
		for(int i =0; i <= 9;i++){
			livre[i] = true;
		}
		for(int i =0; i <= 5;i++){
			sortea[i] = 20;
		}
		cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
		print (bingo);
		//colocar credito
		if( Input.GetButtonDown("P")){
			bancoDados.creditos += bancoDados.pulso;
			//fica verificando acada frame se tem creditos
			bancoDados.salvaCredito();
			
		}
		//ajuda
		if(Input.GetKey(KeyCode.A)){
			pausado = false;
			Time.timeScale = 0.0f;
			ajuda.renderer.enabled = true;
		}
		else{
			Time.timeScale = 1.0f;
			ajuda.renderer.enabled = false;
			pausado = true;
		}


		if(Input.GetKeyDown(KeyCode.B)  && !trava){
			trava = true;
			bApertado = true;

		}
		if(bApertado && cont <= 5){
			bApertado = false;
			espera();
		}
		if(cont == 6){
			cont++;
			atraso3(2.5f);
		}

	}

	void espera(){
		Invoke("atraso",3.0f);
	}
	void atraso(){
	while(!bApertado){
		int bola = Random.Range(0,10);
		if(livre[bola] && cont <= 5){
			livre[bola] = false;
			sortea[cont] = bola;
			Rigidbody2D clone = Instantiate(bolasSorteadas[bola], transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(-Vector3.right*10);
			cont++;
				bApertado = true;
				EscolheNumeros.liberado = true;
		}
	 }
		atrasoFala();
	}

	void atrasoFala(){
		Invoke("fala", 0.5f);
	}
	void fala(){

		if(SomaGanho == 12 && SalvaPontos == 0){
			SalvaPontos++;
			audio.PlayOneShot(pontos[Random.Range(0,2)], 1.0f);
		}
		if(SomaGanho == 13 && SalvaPontos <= 1){
			SalvaPontos = 2;
			audio.PlayOneShot(pontos[Random.Range(2,5)], 1.0f);
		}
	}

	void OnGUI(){
		if(pausado){
			GUILayout.BeginArea(new Rect(Screen.width/30,Screen.height/30,Screen.width/2.8f,Screen.height/10));
			GUILayout.BeginHorizontal ("Box");
			GUILayout.Label("Creditos: "+ bancoDados.carregaCredito(),estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout bonus
			GUILayout.BeginArea(new Rect(Screen.width/30,Screen.height/10,Screen.width/2.8f,Screen.height/10));
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("Pontos: " + SomaGanho, estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout premio pontos
			GUILayout.BeginArea(new Rect(Screen.width/30,Screen.height/5.9f,Screen.width/2.8f,Screen.height/10));
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("Bonus: " +premiacao+" x "+(bancoDados.aposta*ganhoLinhas.bonus[4]),estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout premio
			GUILayout.BeginArea(new Rect(Screen.width/30,Screen.height/4.1f,Screen.width/2.8f,Screen.height/10));
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("Premio: " +(bancoDados.premio),estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			
			GUILayout.BeginArea(new Rect(1,Screen.height/3.2f,Screen.width,Screen.height/5));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("- LINHA 1 muda cartelas.\n- Tecla JOGAR para iniciar o bingo.\n- Informações TECLA AJUDA.",estilo2);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			
		}
	}

	void SomaPremiacao(){

		if(bingo){
			premiacao+= 5;
			if(premiacao >= 1000){
				premiacao = 1000;
				somaPremioGanho();
			}
			else{
				atraso3(0.05f);
			}
		}
		else if(SomaGanho <= 11){
			premiacao++;
			if(premiacao >= 70){
				premiacao = 70;
				somaPremioGanho();
			}
			else{
				atraso3(0.05f);
			}
		}
		else if(SomaGanho == 12){
			premiacao++;
			if(premiacao >= 100){
				premiacao = 100;
				somaPremioGanho();
			}
			else{
				atraso3(0.05f);
			}
		}	
		else if(SomaGanho == 13){
			premiacao++;
			if(premiacao >= 200){
				premiacao = 200;
				somaPremioGanho();
			}
			else{
				atraso3(0.05f);
			}
		}
		else if(SomaGanho >= 14 ){
			premiacao++;
			if(premiacao >= 400){
				premiacao = 400;
				somaPremioGanho();
			}
			else{
				atraso3(0.05f);
			}
		}
	}

	void somaPremioGanho(){
		somador+=1;

		if( somador <= premiacao*bancoDados.aposta*ganhoLinhas.bonus[4]){
			bancoDados.premio+=1;
			atraso4();
		}
		else{
			atraso2();
		}
	}
	
	void voltaGame(){
		ganhoLinhas.bonus[4] = 0;
		Application.LoadLevel("game");
	}
	void atraso2(){
		Invoke("voltaGame",5);
	}
	
	void atraso3(float temp){
		Invoke("SomaPremiacao",temp);

	}
	void atraso4(){
		Invoke("somaPremioGanho",0.01f);
		
	}
}
