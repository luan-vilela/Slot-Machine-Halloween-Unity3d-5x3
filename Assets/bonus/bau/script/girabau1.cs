using UnityEngine;
using System.Collections;

public class girabau1 : MonoBehaviour {

	float move;
	int premiacao;
	public static int somaValor;
	bool livre, addValor, entraPremio;
	public static int multiplicador;
	public AudioClip giro;
	public GUIStyle estilo;

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "bau2Vamp"){
			multiplicador = ganhoLinhas.bonus[6];
		}
		else{
			multiplicador = ganhoLinhas.bonus[1];
		}
		addValor = false;
		livre = false;
		entraPremio = false;
		somaValor = 0;
		move = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetButtonDown("P")){
			bancoDados.creditos += bancoDados.lerPulso();
			//fica verificando acada frame se tem creditos
			bancoDados.EntradaTotal();
			bancoDados.salvaCredito();
			
		}

		if(Input.GetKeyDown(KeyCode.B) && !livre){
			audio.PlayOneShot(giro, 1);
			livre = true;
			addValor = true;
			move = 50 + Random.Range(150,300);
			entraPremio = true;
		}

		if(Application.loadedLevelName == "bau2Vamp"){
			if(!addValor && entraPremio){
				entraPremio = false;
				SomaPremiacao();
			}
		}
		else{
			if(!girabau.addValor && !girabau0.addValor && !addValor && entraPremio){
				entraPremio = false;
				SomaPremiacao();
			}
		}

		transform.Rotate(Vector3.up*move*Time.deltaTime);

		if(Application.loadedLevelName == "bau2Vamp"){
			//numero 1
			if(transform.eulerAngles.y >= 170 && transform.eulerAngles.y <= 175){
				move -= 2f;
				if(move <= 2){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 1;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 170, transform.eulerAngles.z); 
				}
			}
			//numero 2
			if(transform.eulerAngles.y >= 210 && transform.eulerAngles.y <= 215){
				move -= 2f;
				if(move <= 1.5f){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 2;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z); 
				}
			}
			//numero 5
			if(transform.eulerAngles.y >= 250 && transform.eulerAngles.y <= 255){
				move -= 0.5f;
				if(move <= 0.6f){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 5;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 250, transform.eulerAngles.z); 
				}
			}
			//numero 3
			if(transform.eulerAngles.y >= 290 && transform.eulerAngles.y <= 295){
				move -= 1.4f;
				if(move <= 2){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 3;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 290, transform.eulerAngles.z); 
				}
			}
			//numero 6
			if(transform.eulerAngles.y >= 330 && transform.eulerAngles.y <= 335){
				move -= 0.1f;
				if(move <= 0.2f){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 6;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 330, transform.eulerAngles.z); 
				}
			}
			//numero 4
			if(transform.eulerAngles.y >= 10 && transform.eulerAngles.y <= 15){
				move -= 0.5f;
				if(move <= 0.6f){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 4;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 10, transform.eulerAngles.z); 
				}
			}

			//numero 1
			if(transform.eulerAngles.y >= 50 && transform.eulerAngles.y <= 55){
				move -= 2f;
				if(move <= 2){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 1;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 50, transform.eulerAngles.z); 
				}
			}
			//numero 3
			if(transform.eulerAngles.y >= 90 && transform.eulerAngles.y <= 95){
				move -= 1.6f;
				if(move <= 2){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 3;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z); 
				}
			}
			//numero 4
			if(transform.eulerAngles.y >= 130 && transform.eulerAngles.y <= 135){
				move -= 0.5f;
				if(move <= 0.5f){
					if(addValor){
						addValor = false;
						girabau1.somaValor += 4;
					}
					move = 0;
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, 130, transform.eulerAngles.z); 
				}
			}


		}
		else{
				//numero 1
				if(transform.eulerAngles.y >= 170 && transform.eulerAngles.y <= 175){
					move -= 2;
					if(move <= 3){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 100;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 170, transform.eulerAngles.z); 
					}
				}
				//numero 2
				if(transform.eulerAngles.y >= 210 && transform.eulerAngles.y <= 215){
					move -= 2;
					if(move <= 3){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 200;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z); 
					}
				}
				//numero 5
				if(transform.eulerAngles.y >= 250 && transform.eulerAngles.y <= 255){
					move -= 1;
					if(move <= 1){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 500;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 250, transform.eulerAngles.z); 
					}
				}
				//numero 3
				if(transform.eulerAngles.y >= 290 && transform.eulerAngles.y <= 295){
					move -= 0.9f;
					if(move <= 1){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 300;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 290, transform.eulerAngles.z); 
					}
				}
				//numero 6
				if(transform.eulerAngles.y >= 330 && transform.eulerAngles.y <= 335){
					move -= 1;
					if(move <= 1){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 600;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 330, transform.eulerAngles.z); 
					}
				}
				//numero 4
				if(transform.eulerAngles.y >= 10 && transform.eulerAngles.y <= 15){
					move -= 1;
					if(move <= 2){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 400;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 10, transform.eulerAngles.z); 
					}
				}
				
				//numero 1
				if(transform.eulerAngles.y >= 50 && transform.eulerAngles.y <= 55){
					move -= 2;
					if(move <= 3){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 100;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 50, transform.eulerAngles.z); 
					}
				}
				//numero 3
				if(transform.eulerAngles.y >= 90 && transform.eulerAngles.y <= 95){
					move -= 1;
					if(move <= 2){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 300;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z); 
					}
				}
				//numero 4
				if(transform.eulerAngles.y >= 130 && transform.eulerAngles.y <= 135){
					move -= 0.5f;
					if(move <= 0.5f){
						if(addValor){
							addValor = false;
							girabau1.somaValor += 400;
						}
						move = 0;
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, 130, transform.eulerAngles.z); 
					}
				}
			

		}
	}


	void OnGUI(){
	
			GUILayout.BeginArea(new Rect(1,10,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label("Creditos: "+ bancoDados.carregaCredito(),estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout bonus
			GUILayout.BeginArea(new Rect(Screen.width/3,10,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal("box");
			GUILayout.Label("Bonus: " + somaValor+" X "+(bancoDados.aposta*multiplicador), estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			//layout premio
			GUILayout.BeginArea(new Rect(Screen.width - Screen.width/3,10,Screen.width/3.2f,Screen.height/10));
			GUILayout.BeginHorizontal("box");
			if(premiacao >= (bancoDados.aposta*somaValor*multiplicador)){
				GUILayout.Label("Premio: "+ (bancoDados.premio),estilo);
			}
			else{
				GUILayout.Label("Premio: "+ (premiacao + bancoDados.premio),estilo);
			}
			
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			
			GUILayout.BeginArea(new Rect(1,Screen.width/13,Screen.width,Screen.height/9));
			GUILayout.BeginHorizontal("");
			GUILayout.Label("Aperter JOGAR para girar as roletas do Baú.",estilo);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		
	}

	void SomaPremiacao(){
		if(premiacao < (bancoDados.aposta*somaValor*multiplicador)){
			premiacao++;
			
			if(premiacao == (bancoDados.aposta*somaValor*multiplicador)){
				bancoDados.premio +=premiacao;
				atraso2();
			}
			atraso3();
		}
		
	}
	
	void voltaGame(){
		somaValor = 0;
		if(Application.loadedLevelName == "bau2Vamp"){
			ganhoLinhas.bonus[6] = 0;
		}
		else{
			ganhoLinhas.bonus[1] = 0;
		}

		Application.LoadLevel("game");
	}
	void atraso2(){
		Invoke("voltaGame",5);
	}
	
	void atraso3(){
		Invoke("SomaPremiacao",0.01f);
	}

}