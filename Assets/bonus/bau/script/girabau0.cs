using UnityEngine;
using System.Collections;

public class girabau0 : MonoBehaviour {

	float move;
	int premiacao;
	public static int somaValor;
	public static bool livre, addValor;

	// Use this for initialization
	void Start () {
		livre = false;
		addValor = false;
		somaValor = 0;
		move = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.B) && !livre){
			livre = true;
			addValor = true;
			move = 50 + Random.Range(0,200);
		}



		transform.Rotate(Vector3.up*move*Time.deltaTime);

		//numero 1
		if(transform.eulerAngles.y >= 170 && transform.eulerAngles.y <= 175){
			move -=1;
			if(move <= 1){
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
			move -= 0.9f;
			if(move <= 1){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 2;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 210, transform.eulerAngles.z); 
			}
		}
		//numero 3
		if(transform.eulerAngles.y >= 250 && transform.eulerAngles.y <= 255){
			move -= 0.8f;
			if(move <= 1){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 3;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 250, transform.eulerAngles.z); 
			}
		}
		//numero 4
		if(transform.eulerAngles.y >= 290 && transform.eulerAngles.y <= 295){
			move -= 0.7f;
			if(move <= 0.7f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 4;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 290, transform.eulerAngles.z); 
			}
		}
		//numero 5
		if(transform.eulerAngles.y >= 330 && transform.eulerAngles.y <= 335){
			move -= 0.6f;
			if(move <= 0.6f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 5;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 330, transform.eulerAngles.z); 
			}
		}
		//numero 6
		if(transform.eulerAngles.y >= 10 && transform.eulerAngles.y <= 15){
			move -= 0.5f;
			if(move <= 0.5f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 6;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 10, transform.eulerAngles.z); 
			}
		}
		//numero 7
		if(transform.eulerAngles.y >= 50 && transform.eulerAngles.y <= 55){
			move -= 0.4f;
			if(move <= 0.4f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 7;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 50, transform.eulerAngles.z); 
			}
		}
		//numero 8
		if(transform.eulerAngles.y >= 90 && transform.eulerAngles.y <= 95){
			move -= 0.3f;
			if(move <= 0.3f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 8;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z); 
			}
		}
		//numero 9
		if(transform.eulerAngles.y >= 130 && transform.eulerAngles.y <= 135){
			move -= 0.2f;
			if(move <= 0.2f){
				if(addValor){
					addValor = false;
					girabau1.somaValor += 9;
				}
				move = 0;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, 130, transform.eulerAngles.z); 
			}
		}

	}


}