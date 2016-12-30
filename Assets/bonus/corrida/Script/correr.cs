using UnityEngine;
using System.Collections;

public class correr : MonoBehaviour {
	
	bool andando = false, somAndando;
	public GameObject[] ganho = new GameObject[5];
	float porcentagem;

	Animator anim;

	// Use this for initialization
	void Start () {
		somAndando = false;
		anim = GetComponent<Animator>();
		andando = false;
		variaveisCorrer.selecaoBruxa =""+ 0;
		variaveisCorrer.trava = false;
		variaveisCorrer.cont = -1;

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > -7.111828f && !somAndando){
			somAndando = true;
			audio.Play();
		}

		if(somAndando && transform.position.x >= 6){
			audio.Stop();
		}

		if(!variaveisCorrer.trava){
			porcentagem = (bancoDados.lerEntradaTotal()* bancoDados.lerPorcentagem() - bancoDados.lerSaida());
		}

		if(Input.GetKeyDown("y") && !variaveisCorrer.trava){
			variaveisCorrer.trava = true;
			variaveisCorrer.selecaoBruxa =""+ 1;
		}
		if(Input.GetKeyDown("j") && !variaveisCorrer.trava){
			variaveisCorrer.trava = true;
			variaveisCorrer.selecaoBruxa =""+ 2;
		}
		if(Input.GetKeyDown("h") && !variaveisCorrer.trava){
			variaveisCorrer.trava = true;
			variaveisCorrer.selecaoBruxa =""+ 3;
		}
		if(Input.GetKeyDown("m")&& !variaveisCorrer.trava){
			variaveisCorrer.trava = true;
			variaveisCorrer.selecaoBruxa =""+ 4;
		}
		if(Input.GetKeyDown("n") && !variaveisCorrer.trava){
			variaveisCorrer.trava = true;
			variaveisCorrer.selecaoBruxa =""+ 5;
		}

			


		anim.SetBool("andando", andando);
		if(variaveisCorrer.selecaoBruxa != "" + 0){

			if(gameObject.transform.position.x <= 6){
				andando = true;
				//verifica se pode pagar bonus
				if(porcentagem < bancoDados.aposta*150*ganhoLinhas.bonus[0] && gameObject.tag == variaveisCorrer.selecaoBruxa){
					if(Random.Range(0,5) > 2){
						transform.Translate(Random.Range(0,2.5f)*Time.deltaTime,0,0);
					}
					else if(Random.Range(0,5) == 2){
						transform.Translate(Random.Range(0,3.0f)*Time.deltaTime,0,0);
					}
					else{
						transform.Translate(Random.Range(0,0.4f)*Time.deltaTime,0,0);
					}
					
				}
				else{
					if(Random.Range(0,5) > 2){
						transform.Translate(Random.Range(0,2.5f)*Time.deltaTime,0,0);
					}
					else if(Random.Range(0,5) == 2){
						transform.Translate(Random.Range(0,4.0f)*Time.deltaTime,0,0);
					}
					else{
						transform.Translate(Random.Range(0,0.4f)*Time.deltaTime,0,0);
					}
				}
			}
			else{
				 if(andando){
					variaveisCorrer.cont++;
					andando = false;
					switch(int.Parse(gameObject.tag)){
					case 1:
						ganho[variaveisCorrer.cont].transform.position = new Vector2(4.02f,2.62f);
						ganho[variaveisCorrer.cont].renderer.enabled = true;
						break;
					case 2:
						ganho[variaveisCorrer.cont].transform.position = new Vector2(4.02f,1.13f);
						ganho[variaveisCorrer.cont].renderer.enabled = true;
						break;
					case 3:
						ganho[variaveisCorrer.cont].transform.position = new Vector2(4.02f,-0.5f);
						ganho[variaveisCorrer.cont].renderer.enabled = true;
						break;
					case 4:
						ganho[variaveisCorrer.cont].transform.position = new Vector2(4.02f,-2.03f);
						ganho[variaveisCorrer.cont].renderer.enabled = true;
						break;
					case 5:
						ganho[variaveisCorrer.cont].transform.position = new Vector2(4.02f,-3.59f);
						ganho[variaveisCorrer.cont].renderer.enabled = true;
						break;
					}
					if(gameObject.tag == variaveisCorrer.selecaoBruxa){
						switch(variaveisCorrer.cont){
						case 0:
							layoutCorrer.bonus = 300;
							break;
						case 1:
							layoutCorrer.bonus = 200;
							break;
						case 2:
							layoutCorrer.bonus = 150;
							break;
						case 3:
							layoutCorrer.bonus = 75;
							break;
						case 4:
							layoutCorrer.bonus = 50;
							break;
						}

					}
				}



			}
		}
	}
}
