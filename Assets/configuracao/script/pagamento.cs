using UnityEngine;
using System.Collections;

public class pagamento : MonoBehaviour {
	public GUIText paga;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		paga.text = "R$ " + string.Format("{0:0,0.00}", (bancoDados.carregaCredito()*1.0f/bancoDados.lerPulso()) );
		if(Input.GetKeyDown(KeyCode.B)){
			Application.LoadLevel("game");
		}
		if(Input.GetKeyDown(KeyCode.R)){
			bancoDados.saida();
			bancoDados.creditos = -bancoDados.carregaCredito();
			bancoDados.salvaCredito();
			Invoke("atraso",3);

		}
	}
	void atraso(){
		Application.LoadLevel("game");
	}
}
