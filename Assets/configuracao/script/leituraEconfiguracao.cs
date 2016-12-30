using UnityEngine;
using System.Collections;

public class leituraEconfiguracao : MonoBehaviour {
	public GUIText entradaTotal, saidaTotal, porcentagem, previsao, contabilidade;
	public GUIText[] acum1 = new GUIText[4];
	public GUIText[] acum2 = new GUIText[4];
	bool[] senha = new bool[6];
	int cont;
	string pass = null;
	bool entrarSenha;
	int valor = 1;

	void Start(){
		pass = null;
		for(int i = 0; i <= senha.Length-1;i++){
			senha[i] = false;
		}
		cont = 0;
	}

	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "configuracao"){
			if(Input.GetKeyDown(KeyCode.B) ){
				Application.LoadLevel("game");
			}
			if(Input.GetKeyDown(KeyCode.Y) ){
				Application.LoadLevel("leitura");
			}
			if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.H) ){
				Application.LoadLevel("senha");
			}
			if(Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.H) ){
				Application.LoadLevel("testeInput");
			}
		}

		if(Application.loadedLevelName == "leitura"){
			entradaTotal.text = "Entrada  R$ " + (bancoDados.lerEntradaTotal()/bancoDados.lerPulso());
			saidaTotal.text = "Saída R$ " + (bancoDados.lerSaida()/bancoDados.lerPulso());
			porcentagem.text = "Regulagem: " + (bancoDados.lerPorcentagem()*100)+"%";
			previsao.text = "Previsão de PG. R$ " + ((bancoDados.lerEntradaTotal()* bancoDados.lerPorcentagem() - bancoDados.lerSaida())/bancoDados.lerPulso());
			acum1[0].text = "Créditos Jogados: " + bancoDados.lerEntradaPorcentagem();
			acum1[1].text = "Premiação total: " + bancoDados.lerSaidaPorcentagem();
			acum1[2].text = "% de Pagamento: " + string.Format("{0:0.00}",(bancoDados.lerSaidaPorcentagem()*100)/bancoDados.lerEntradaPorcentagem()  ) + "%";
			if(Input.GetKeyDown(KeyCode.B)){
				Application.LoadLevel("configuracao");
			}
		}
		if(Application.loadedLevelName == "senha"){
			switch(cont){
			case 0:
				entradaTotal.text = "";
				break;
			case 1:
				entradaTotal.text = "*";
				break;
			case 2:
				entradaTotal.text = "**";
				break;
			case 3:
				entradaTotal.text = "***";
				break;
			case 4:
				entradaTotal.text = "****";
				break;
			case 5:
				entradaTotal.text = "*****";
				break;
			case 6:
				entradaTotal.text = "******";
				break;
			
			}

			if(Input.GetKeyDown(KeyCode.G) || entrarSenha){
				entrarSenha = true;

				if(Input.GetKeyDown(KeyCode.Y)){
					cont++;
					pass += "1";
				}
				if(Input.GetButtonDown("J")){
					cont++;
					pass += "2";
				}
				if(Input.GetKeyDown(KeyCode.H)){
					cont++;
					pass += "3";
				}
				if(Input.GetKeyDown(KeyCode.M)){
					cont++;
					pass += "4";
				}
				if(Input.GetKeyDown(KeyCode.N)){
					cont++;
					pass += "5";
				}
				if(Input.GetKeyDown(KeyCode.R)){
					cont++;
					pass += "6";
				}

				if(pass == "134615"){
					Application.LoadLevel("configuracaoMaquina");
				}
				// FORMATA JOGO
				if(pass == "111615"){ 
					bancoDados.formata();
					Application.LoadLevel("game");
				}

				if(cont > 5){
					cont = 0;
					entrarSenha = false;
					pass = null;
				}

			}
			else if(Input.GetKeyDown(KeyCode.B)){
				Application.LoadLevel("configuracao");
			}



		}

		if(Application.loadedLevelName == "configuracaoMaquina"){

			//acumulado maximo
			acum1[0].text = "" + bancoDados.lerMAXIMO1();
			acum2[0].text = "" + bancoDados.lerMAXIMO2();
			//acumulado minino
			acum1[1].text = "" + bancoDados.lerMINIMO1();
			acum2[1].text = "" + bancoDados.lerMINIMO2();
			//porcentagem dos acumulados
			acum1[2].text = "" + bancoDados.lerPorcentagemAcumulado1()*100 + "%";
			acum2[2].text = "" + bancoDados.lerPorcentagemAcumulado2()*100 + "%";
			//acumulado atual
			acum1[3].text = "" + bancoDados.lerAcumulado1();
			acum2[3].text = "" + bancoDados.lerAcumulado2();
			//entrada
			entradaTotal.text = "" + bancoDados.lerEntradaTotal()/bancoDados.lerPulso();
			//delay
			saidaTotal.text = "" + bancoDados.lerSaida();
			//pulso
			porcentagem.text = "" + bancoDados.lerPulso();
			//retencao
			previsao.text = "" + bancoDados.lerPorcentagem()*100+"%";



			if(valor > 100) valor = 1;
			if(cont > 11) cont = 0;
			contabilidade.text ="A variação está em: " + valor;
			acum1[0].guiText.color = Color.white;
			acum2[0].guiText.color = Color.white;
			acum1[1].guiText.color = Color.white;
			acum2[1].guiText.color = Color.white;
			acum1[2].guiText.color = Color.white;
			acum2[2].guiText.color = Color.white;
			acum1[3].guiText.color = Color.white;
			acum2[3].guiText.color = Color.white;
			entradaTotal.guiText.color = Color.white;
			porcentagem.guiText.color = Color.white;
			previsao.guiText.color = Color.white;
			saidaTotal.guiText.color = Color.white;

			if(Input.GetKeyDown(KeyCode.Y))	cont++;
			if(Input.GetKeyDown(KeyCode.B))	Application.LoadLevel("configuracao");
			//ACUMULADO MAXIMO ABOBORAS 1
			if(cont == 0){
				acum1[0].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.MAXIMO1();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.MAXIMO1();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.MAXIMO1();
				}
			}
			//ACUMULADO MINIMO ABOBORAS 1
			if(cont == 1){
				acum1[1].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.MINIMO1();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.MINIMO1();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.MINIMO1();
				}
			}
			//ACUMULADO PORCETAGEM ABOBORA
			if(cont == 2){
				acum1[2].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.porcentagemAcumulado1();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.porcentagemAcumulado1();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.porcentagemAcumulado1();
				}
			}
			//ACUMULADO ATUAL ABOBORA
			if(cont == 3){
				acum1[3].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.confAcumulado1();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.confAcumulado1();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.confAcumulado1();
				}
			}
		
			//ACUMULADO MAXIMO ABOBORAS 2
			if(cont == 4){
				acum2[0].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.MAXIMO2();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.MAXIMO2();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.MAXIMO2();
				}
			}
			//ACUMULADO MINIMO ABOBORAS 1
			if(cont == 5){
				acum2[1].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.MINIMO2();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.MINIMO2();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.MINIMO2();
				}
			}
			//ACUMULADO PORCETAGEM ABOBORA
			if(cont == 6){
				acum2[2].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.porcentagemAcumulado2();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.porcentagemAcumulado2();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.porcentagemAcumulado2();
				}
			}
			//ACUMULADO ATUAL ABOBORA
			if(cont == 7){
				acum2[3].guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.ConfiguraAcumuladoM1 = 0;
					bancoDados.confAcumulado2();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.ConfiguraAcumuladoM1 += valor;
					bancoDados.confAcumulado2();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.ConfiguraAcumuladoM1 -= valor;
					bancoDados.confAcumulado2();
				}
			}

			//pulso
			if(cont == 8){
				porcentagem.guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.pulso = 0;
					bancoDados.SalvaPulso();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.pulso += valor;
					bancoDados.SalvaPulso();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.pulso -= valor;
					bancoDados.SalvaPulso();
				}
			}
			//retencao
			if(cont == 9){
				previsao.guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.porcentagemCasa = 0;
					bancoDados.porcentagem();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.porcentagemCasa += valor;
					bancoDados.porcentagem();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.porcentagemCasa -= valor;
					bancoDados.porcentagem();
				}
			}
			//entrada
			if(cont == 10){
				entradaTotal.guiText.color = Color.red;
				//ZERA
				if(Input.GetKeyDown(KeyCode.J)){
					bancoDados.pulso = 0;
					bancoDados.ConfigEntrada();
				}
				//VARIA VALOR 1, 10 OU 100
				if(Input.GetKeyDown(KeyCode.H)){
					valor *= 10;
				}
				// AUMENTAR
				if(Input.GetKeyDown(KeyCode.M)){
					bancoDados.pulso += valor;
					bancoDados.ConfigEntrada();
				}
				// DIMINUIR
				if(Input.GetKeyDown(KeyCode.N)){
					bancoDados.pulso -= valor;
					bancoDados.ConfigEntrada();
				}
			}
			//delay
			if(cont == 11){
				cont++;
			}

		
		
		}

		if(Application.loadedLevelName == "testeInput"){
			if(Input.GetKeyDown(KeyCode.B)){
				if(valor > 1){
					acum2[3].guiText.enabled = false;
					acum2[2].text = "R$ 0";
					valor = 1;
				}
				else{
					Application.LoadLevel("configuracao");
				}
			}
			if(Input.GetKey(KeyCode.Y)){
				entradaTotal.guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.J)){
				saidaTotal.guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.H)){
				porcentagem.guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.M)){
				previsao.guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.N)){
				contabilidade.guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.F)){
				acum1[0].guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.T)){
				acum1[1].guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.V)){
				acum1[2].guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.G)){
				acum1[3].guiText.color = Color.red;
			}
			if(Input.GetKey(KeyCode.R)){
				acum2[0].guiText.color = Color.red;
			}
			if(Input.GetButton("quatro") || Input.GetKey(KeyCode.Keypad4)){
				acum2[1].guiText.color = Color.red;
			}
			if(Input.GetKeyDown(KeyCode.P)){
				acum2[2].text = "R$ " + valor;
				valor++;
				acum2[3].guiText.enabled = true;
			}

		}
	}
}
