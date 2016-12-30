using UnityEngine;
using System.Collections;
using System;

public class bancoDados : MonoBehaviour {

	public static int creditos, ganho, aposta = 1, premio = 0, valorAposta = 1, pulso;
	public static float delayParada = 1.5F, valorPorcentagem = 1.0f, rotacao = 1.5f, porcentagemCasa;//2.2f
	public static float bonus1 = 0, bonus2= 0;
	public static bool Bonus1Entrada, Bonus2Entrada;
	public static float ConfiguraAcumuladoM1;

	
	public static void salvaCredito(){
		int credito = creditos + carregaCredito();
		creditos =0;
		PlayerPrefs.SetInt("credito", credito);
	}
	public static int carregaCredito(){
		int cred = PlayerPrefs.GetInt("credito", 0);
		return cred;
	}
	public static void ConfigEntrada(){
		int entradaT = pulso;
		PlayerPrefs.SetInt("EntradaTotal", entradaT);
	}
	//armazena tudo que entrou na maquina o bruto
	public static void EntradaTotal(){
		int entradaT =  lerPulso() + lerEntradaTotal();
		PlayerPrefs.SetInt("EntradaTotal", entradaT);
	}
	public static int lerEntradaTotal(){
		int leu = PlayerPrefs.GetInt("EntradaTotal", 0);
		return leu;
	}
	//entra aqui toda vez que aperta jogar
	// isso e o que a maquina tem para pagar
	// usado para ver o quando a maquina paga
	//**************************************************************
	public static void entradaPorcentagem(){
		float totalEntrada = (valorAposta*aposta*layout.tecla);
		totalEntrada +=lerEntradaPorcentagem();
		PlayerPrefs.SetFloat("EntradaPorcentagem", totalEntrada);
		
	}
	public static float lerEntradaPorcentagem(){
		float leu = PlayerPrefs.GetFloat("EntradaPorcentagem", 0);
		return leu;
	}
	public static void saidaPorcentagem(){
		float totalEntrada = premio;
		totalEntrada +=lerSaidaPorcentagem();
		PlayerPrefs.SetFloat("SaidaPorcentagem", totalEntrada);
		
	}
	public static float lerSaidaPorcentagem(){
		float leu = PlayerPrefs.GetFloat("SaidaPorcentagem", 0);
		return leu;
	}



	//dinheiro da casa
	//entra aqui quando tem premiacao script ganholinhas
	// isso e que calcula o que pode pagar
	public static void saida(){
		float Entrada = carregaCredito();
		Entrada +=lerSaida();
		PlayerPrefs.SetFloat("Saida", Entrada);

	}
	public static float lerSaida(){
		float leu = PlayerPrefs.GetFloat("Saida", 0);
		return leu;
	}
	//sem uso
	public static void porcentagem(){
		float porcento = porcentagemCasa/100;
		PlayerPrefs.SetFloat("Porcentagem", porcento);
	}
	public static float lerPorcentagem(){
		float leu = PlayerPrefs.GetFloat("Porcentagem", 0);
		if(leu == 0){
			float porcento = 0.5f;
			PlayerPrefs.SetFloat("Porcentagem", porcento);
			leu = PlayerPrefs.GetFloat("Porcentagem", 0);
		}
		return leu;
	}
	public static void SalvaPulso(){
		float entrada = pulso;
		PlayerPrefs.SetFloat("Pulso", entrada);
	}
	public static int lerPulso(){
		int leu = PlayerPrefs.GetInt("Pulso", 0);
		if(leu == 0){
			int entrada = 100;
			PlayerPrefs.SetInt("Pulso", entrada);
			leu = PlayerPrefs.GetInt("Pulso", 0);
		}
		return leu;
	}
	//acumulado maximo 1
	public static void MAXIMO1(){
		float entrada = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("MAXIMO1", entrada);
	}
	public static float lerMAXIMO1(){
		float leu = PlayerPrefs.GetFloat("MAXIMO1", 0);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 250
			float entrada = 250;
			PlayerPrefs.SetFloat("MAXIMO1", entrada);
			leu = PlayerPrefs.GetFloat("MAXIMO1", 0);
		}
		return leu;
	}
	//acumulado maximo 2
	public static void MAXIMO2(){
		float entrada = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("MAXIMO2", entrada);
	}
	public static float lerMAXIMO2(){
		float leu = PlayerPrefs.GetFloat("MAXIMO2", 0);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 200
			float entrada = 200;
			PlayerPrefs.SetFloat("MAXIMO2", entrada);
			leu = PlayerPrefs.GetFloat("MAXIMO2", 0);
		}
		return leu;
	}

	//acumulado minimo 1
	public static void MINIMO1(){
		float entrada = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("MINIMO1", entrada);
	}
	public static float lerMINIMO1(){
		float leu = PlayerPrefs.GetFloat("MINIMO1", 0);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 200
			float entrada = 100;
			PlayerPrefs.SetFloat("MINIMO1", entrada);
			leu = PlayerPrefs.GetFloat("MINIMO1", 0);
		}
		return leu;
	}
	//acumulado minimo 2
	public static void MINIMO2(){
		float entrada = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("MINIMO2", entrada);
	}
	public static float lerMINIMO2(){
		float leu = PlayerPrefs.GetFloat("MINIMO2", 0);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 200
			float entrada = 75;
			PlayerPrefs.SetFloat("MINIMO2", entrada);
			leu = PlayerPrefs.GetFloat("MINIMO2", 0);
		}
		return leu;
	}
	//configuracao do acumulado 1
	public static void confAcumulado1(){
		float acumulado = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("Acumulado1", acumulado);
	}
	//configuracao do acumulado 2
	public static void confAcumulado2(){
		float acumulado = ConfiguraAcumuladoM1;
		PlayerPrefs.SetFloat("Acumulado2", acumulado);
	}
	public static void acumulado1(){
		float acumulado = ((layout.tecla*aposta*valorAposta)/Convert.ToSingle(lerPulso()))*lerPorcentagemAcumulado1();
		Debug.LogWarning("acumulado 1 " + acumulado);
		acumulado = lerAcumulado1() + acumulado;
		Debug.LogWarning("acumulado 1 + ler " + acumulado);
		//se for true reseta o acumulado
		if(Bonus1Entrada){
			Bonus1Entrada = false;
			acumulado = bonus1;
		}
		PlayerPrefs.SetFloat("Acumulado1", acumulado);
	}
	public static float lerAcumulado1(){
		float leu = PlayerPrefs.GetFloat("Acumulado1", 0.000f);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 200
			float entrada = 100;
			PlayerPrefs.SetFloat("Acumulado1", entrada);
			leu = PlayerPrefs.GetFloat("Acumulado1", 0);
		}
		return leu;
	}
	public static void acumulado2(){
		float acumulado = ((layout.tecla*aposta*valorAposta)/Convert.ToSingle(lerPulso()))*lerPorcentagemAcumulado2();
		Debug.LogWarning("acumulado 2 " + acumulado);
		acumulado = lerAcumulado2() + acumulado;
		Debug.LogWarning("acumulado 2 + ler " + acumulado);
		//se for true reseta o acumulado
		if(Bonus2Entrada){
			Bonus2Entrada = false;
			acumulado = bonus2;
		}
		PlayerPrefs.SetFloat("Acumulado2", acumulado);
	}
	public static float lerAcumulado2(){
		float leu = PlayerPrefs.GetFloat("Acumulado2", 0);
		if(leu == 0){ // se nao tiver nada salvo vai dar o valor de 200
			float entrada = 100;
			PlayerPrefs.SetFloat("Acumulado2", entrada);
			leu = PlayerPrefs.GetFloat("Acumulado2", 0);
		}
		return leu;
	}
	// porcentagem para subir acumulado 1
	public static void porcentagemAcumulado1(){
		float porcento = ConfiguraAcumuladoM1/100.0f;
		PlayerPrefs.SetFloat("PorcentagemAC", porcento);
	}
	public static float lerPorcentagemAcumulado1(){
		float leu = PlayerPrefs.GetFloat("PorcentagemAC", 0);
		if(leu == 0){
			float porcento = 1/100.00f;
			PlayerPrefs.SetFloat("PorcentagemAC", porcento);
			leu = PlayerPrefs.GetFloat("PorcentagemAC", 0);
		}

		return leu;
	}
	// porcentagem para subir acumulado 2
	public static void porcentagemAcumulado2(){
		float porcento = ConfiguraAcumuladoM1/100.0f;
		PlayerPrefs.SetFloat("PorcentagemAC2", porcento);
	}
	public static float lerPorcentagemAcumulado2(){
		float leu = PlayerPrefs.GetFloat("PorcentagemAC2", 0);
		if(leu == 0){
			float porcento = 2/100.00f;
			PlayerPrefs.SetFloat("PorcentagemAC2", porcento);
			leu = PlayerPrefs.GetFloat("PorcentagemAC2", 0);
		}
		return leu;
	}

	public static void formata(){
		PlayerPrefs.DeleteAll();

	}



}
	