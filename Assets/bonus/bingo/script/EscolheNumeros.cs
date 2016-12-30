using UnityEngine;
using System.Collections;

public class EscolheNumeros : MonoBehaviour {
	public Sprite[] objPreto = new Sprite[10];
	public Sprite[] objVermelho = new Sprite[10];
	public GameObject[] objetos = new GameObject[6];
	bool[] escolhido = new bool[10];
	int[] armazena = new int[6];
	bool[] ficouVermelho = new bool[6];
	int cont;
	public static bool liberado;
	// Use this for initialization
	void Start () {
		for(int i = 0; i <= 9;i++){
			escolhido[i] = true;
		}
		for(int i = 0; i <= 5;i++){
			ficouVermelho[i] = true;
		}
		cont = 0;
		while(cont <= 5){
			int salva = Random.Range(0,10);
			if(escolhido[salva]){
				escolhido[salva] = false; //tira numero da escolha para nao repetir
				objetos[cont].GetComponent<SpriteRenderer>().sprite = objPreto[salva];
				armazena[cont] = salva;
				cont++;
				if(cont == 6){
					for(int i = 0; i <= 9;i++){
						escolhido[i] = true;
					}
				}
			}
		}
		cont = 0;
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.Y) && !sorteaNumeros.trava){
			audio.Play();
			Start();
		}


		if(liberado){
			for(int k = 0; k <= 5;k++){
				for(int i = 0; i <= 5;i++){
					if(armazena[k] == sorteaNumeros.sortea[i] && ficouVermelho[k]){
						objetos[k].GetComponent<SpriteRenderer>().sprite = objVermelho[sorteaNumeros.sortea[i]];
						ficouVermelho[k] = false;
						sorteaNumeros.SomaGanho++;
					}
				}
			}
			if(!ficouVermelho[0] && !ficouVermelho[1] && !ficouVermelho[2] && !ficouVermelho[3] && !ficouVermelho[4] && !ficouVermelho[5]){
				sorteaNumeros.bingo = true;
			}
		}
	}




}
