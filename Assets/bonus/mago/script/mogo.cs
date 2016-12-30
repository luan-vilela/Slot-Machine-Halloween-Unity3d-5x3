using UnityEngine;
using System.Collections;

public class mogo : MonoBehaviour {
	public Rigidbody fogo;
	Animator anim;
	bool tiroLiberado, pausado;
	public static int somaMoedas;
	int premiacao;
	public Texture2D img;
	public GUIStyle estilo,estilo2;

	// Use this for initialization
	void Start () {
		somaMoedas = 0;
		tiroLiberado = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetButtonDown("P")){
			bancoDados.creditos += bancoDados.pulso;
			//fica verificando acada frame se tem creditos
			bancoDados.salvaCredito();
			
		}
		if(Input.GetKey(KeyCode.A)){
			Time.timeScale = 0;
			pausado = false;
			GameObject.Find("ajuda").renderer.enabled = true;
		}
		else{
			Time.timeScale = 1.0f;
			pausado = true;
			GameObject.Find("ajuda").renderer.enabled = false;
		}


		if(Input.GetKeyDown(KeyCode.B) && tiroLiberado){
			anim.SetBool("atira",true);
			atraso(); 
			tiroLiberado = false;
		}
		else{
			 
		}

		if(andar.fimDeBonus){
			andar.fimDeBonus = !andar.fimDeBonus;
			SomaPremiacao();
			
		}


	}
	void liberado(){

		Rigidbody clone = Instantiate(fogo,new Vector3(-0.384f,3.0418f),transform.rotation) as Rigidbody;
		anim.SetBool("atira",false);
		Invoke("liberado2",0.6f);
	}

	void atraso(){
		Invoke("liberado",0.2f);

	}

	void liberado2(){
		tiroLiberado = true;
	}

	void OnGUI(){

		if(pausado){
			GUILayout.BeginArea(new Rect(1,1,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal ("");
			GUILayout.Label("Creditos: "+ bancoDados.carregaCredito(),estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout bonus
			GUILayout.BeginArea(new Rect(Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("Bonus: " + somaMoedas+" X "+(bancoDados.aposta*layout.tecla), estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout premio
			GUILayout.BeginArea(new Rect(Screen.width - Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("Premio: "+ premiacao,estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			
			GUILayout.BeginArea(new Rect(1,Screen.width/15,Screen.width,Screen.height/9));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("Aperter JOGAR para lançar a mágica na Medusa.",estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();




			GUILayout.BeginArea(new Rect(Screen.width/1.5f,Screen.height/1.065857f,Screen.width/10,Screen.height/12));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("" +andar.unidadesMoedas, estilo2);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(Screen.width/1.13f,Screen.height/1.065857f,Screen.width/10,Screen.height/12));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("" +andar.unidadesDiamante, estilo2);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();

		}

	}


	void SomaPremiacao(){
		if(premiacao < (bancoDados.aposta*layout.tecla*somaMoedas)){
			premiacao++;
			
			if(premiacao == (bancoDados.aposta*layout.tecla*somaMoedas)){
				bancoDados.premio +=premiacao;
				atraso2();
			}
			atraso3();
		}
		
	}
	
	void voltaGame(){
		somaMoedas = 0;
		Application.LoadLevel("game");
	}
	void atraso2(){
		Invoke("voltaGame",5);
	}
	
	void atraso3(){
		Invoke("SomaPremiacao",0.01f);
	}
}
