/*
Jogo que o jogador tem que somar 7 nos dados
 */


using UnityEngine;
using System.Collections;

public class lancaDado : MonoBehaviour {

	public AudioClip[] go = new AudioClip[2];
	public AudioClip yeh;
	int cont = 1;
	public Rigidbody dados;
	Rigidbody clone;
	public static bool jogar =true,parado = false,ObjCriado, seguraResultado, emcavalo;
	bool recebePremio;
	public GUIStyle estilo;
	int premiacao,  salvaAudio;
	int multiplicador;//multiplicador se tirar vampiro 20 se tirar magico 200

	
	// Use this for initialization
	void Start () {
		multiplicador = ganhoLinhas.bonus[2];
		emcavalo = false;
		jogar = true;
		recebePremio = true;
		salvaAudio = Random.Range(0,2);
		audio.PlayOneShot(go[salvaAudio]);
		//ativa a multidao falando gogogogogo e conta os segundos para começar o proximo shot de gogo
		while(go[salvaAudio].length*cont <= Time.time){
			cont+=2;
		}

	}
	
	// Update is called once per frame
	void Update () {


		if(go[salvaAudio].length*cont <= Time.time){
			cont++;
			if(jogar) audio.PlayOneShot(go[salvaAudio]);
		}




		if(Input.GetButtonDown("P")){
			bancoDados.creditos++;
		}
		if(Input.GetButtonDown("B") && jogar){
			audio.PlayOneShot(yeh);
			jogar = false;
			clone = Instantiate(dados,transform.position,transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Random.Range(-2.5f,2.5f),6/Random.Range(1,2.1f),Random.Range(1,11.1f));
			clone.rotation = Random.rotation;
			ObjCriado = true;
			destroiObj.caiu = false;
			Invoke("destruirDado",15);
		}
		if(ObjCriado){
			if(clone.velocity == Vector3.zero){
				parado = true;
				//seguraResultado = true;
				ObjCriado = false;

			}
		}

		if((mesaDado.soma*multiplicador) != 0){
			if((mesaDado.soma*multiplicador*bancoDados.aposta) <= premiacao){
				atraso(3);
			}
			else{
				premiacao += 10;
			}
		}

	}

	
	void passaTela(){
		ganhoLinhas.bonus[2] = 0;
		Application.LoadLevel("game");
	}
	void pagaPremio(){
		if(recebePremio){
			recebePremio = false;
			bancoDados.premio +=(mesaDado.soma*multiplicador*bancoDados.aposta);
			bancoDados.salvaCredito();
		}
	}

	void atraso(int temp){

		Invoke("pagaPremio",1.5f);
		Invoke("passaTela",temp);
	}
	void destruirDado(){
		if(mesaDado.soma == 0 && !destroiObj.caiu){
			jogar = true;
			destroiObj.caiu = true;
		}
	}

	void OnGUI(){

		//layout Creditos
		GUILayout.BeginArea(new Rect(1,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal ("box");
		GUILayout.Label("Creditos: "+ bancoDados.carregaCredito(),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout bonus
		GUILayout.BeginArea(new Rect(Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Bonus: " +mesaDado.soma+ " X "+(multiplicador*bancoDados.aposta),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout premio
		GUILayout.BeginArea(new Rect(Screen.width - Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		if(recebePremio){
			GUILayout.Label("Premio: "+ (premiacao + bancoDados.premio),estilo);
		}
		else{
			GUILayout.Label("Premio: "+ (bancoDados.premio),estilo);
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(1,Screen.height-Screen.height/18,Screen.width,Screen.height/10));
		GUILayout.BeginHorizontal();
		
		if(destroiObj.caiu){
				GUILayout.Label("OPS: Seu dado caiu da mesa, jogue de novo! ",estilo );
		}
		else{
			if(jogar) GUILayout.Label("Aperte JOGAR para jogar o dado.",estilo );
			else GUILayout.Label("Muito bem, agora é só ver a pontuação.",estilo );
		}
		if(emcavalo){
			GUILayout.Label("OPS: Seu dado ficou emcavalado, JOGUE NOVAMENTE! ",estilo );
		}

		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
