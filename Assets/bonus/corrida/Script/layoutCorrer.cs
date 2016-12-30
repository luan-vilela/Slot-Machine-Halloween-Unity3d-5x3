using UnityEngine;
using System.Collections;

public class layoutCorrer : MonoBehaviour {

	int multiplicador = bancoDados.aposta, premiacao;
	public static int BonusVezes;
	public GUIStyle estilo;
	public static int bonus;
	bool ajuda, entraSoma;

	void Start(){
		BonusVezes = ganhoLinhas.bonus[0];
		ajuda = entraSoma = false;
		premiacao = 0;
		bonus = 0;
	}


	void Update(){

		if(Input.GetKeyDown(KeyCode.P)){
			bancoDados.creditos += bancoDados.pulso;
			bancoDados.salvaCredito();
		}

		if(Input.GetKey(KeyCode.T)){
			ajuda = true;
			GameObject.Find("Ajuda").renderer.enabled = true;
		}
		else{
			GameObject.Find("Ajuda").renderer.enabled = false;;
			ajuda = false;
		}

		if(bonus != 0 && variaveisCorrer.cont == 4 && !entraSoma){
			entraSoma = !entraSoma;
			SomaPremiacao();

		}
	}

	void OnGUI(){
		if(ajuda) return;
		//layout Creditos
		GUILayout.BeginArea(new Rect(1,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal ("box");
		GUILayout.Label("Creditos: "+ bancoDados.carregaCredito(),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout bonus
		GUILayout.BeginArea(new Rect(Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Bonus: " + bonus+" X "+(multiplicador*BonusVezes), estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//layout premio
		GUILayout.BeginArea(new Rect(Screen.width - Screen.width/3,1,Screen.width/3.2f,Screen.height/10));
		GUILayout.BeginHorizontal("box");
		if(premiacao < (bonus*multiplicador*BonusVezes))GUILayout.Label("Premio: "+ (premiacao + bancoDados.premio),estilo);
		else GUILayout.Label("Premio: "+ (bancoDados.premio),estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(1,Screen.width/15,Screen.width,Screen.height/10));
		GUILayout.BeginHorizontal("");
		GUILayout.Label("Multiplique seu bônus por x50, x75, x150, x200 ou x300 ",estilo);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	void SomaPremiacao(){
		if(premiacao < (bonus*multiplicador*BonusVezes)){
			premiacao++;

			if(premiacao == (bonus*multiplicador*BonusVezes)){
				bancoDados.premio +=premiacao;
				//bancoDados.saida();
				atraso2();
			}
			atraso();
		}

	}

	void voltaGame(){
		BonusVezes = 0;
		ganhoLinhas.bonus[0] = 0;
		Application.LoadLevel("game");
	}
	void atraso2(){
		Invoke("voltaGame",5);
	}

	void atraso(){
		Invoke("SomaPremiacao",0.001f);
	}
}
