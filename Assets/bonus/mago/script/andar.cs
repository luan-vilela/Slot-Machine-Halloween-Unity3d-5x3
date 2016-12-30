using UnityEngine;
using System.Collections;

public class andar : MonoBehaviour {
	Animator anim;
	bool morto;
	public GameObject explodir;
	public Rigidbody[] moeda = new Rigidbody[3];
	public static bool fimDeBonus, terminoBonus;
	public static int unidadesMoedas, unidadesDiamante;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!morto){
			transform.Translate(Vector3.right*2*Time.deltaTime);
		}
		if(transform.position.x > 8) Destroy(gameObject);

	}

	void OnTriggerEnter2D(Collider2D obj) {
		Destroy(obj);
		anim.SetBool("baleada",true);
		morto = true;
		gameObject.tag = "Untagged";
		Destroy(collider2D);
		Instantiate(explodir, transform.position, transform.rotation);
		int quantMoedas = Random.Range(0,51);
		int escolheMoeda;
		if(quantMoedas == 50){
			escolheMoeda = 2;
			fimDeBonus = true;
			terminoBonus = true;
		}
		else if(quantMoedas > 5 && quantMoedas < 50){
			quantMoedas = Random.Range(0,10);
			escolheMoeda = 0;
			mogo.somaMoedas += quantMoedas +1;
			unidadesMoedas += quantMoedas +1;
		}
		else{
			quantMoedas = Random.Range(0,5);
			escolheMoeda = 1;
			mogo.somaMoedas += (quantMoedas+1)*5;
			unidadesDiamante += (quantMoedas+1)*5;
		}
		Rigidbody moedaCriada;
		for(int i = 0; i <= quantMoedas; i++){
			moedaCriada = Instantiate(moeda[escolheMoeda], transform.position, transform.rotation) as Rigidbody;
			moedaCriada.velocity = transform.TransformDirection(new Vector3(Random.Range(-3,3),Random.Range(3,8)));
			moedaCriada.rotation = Random.rotation;
		}
	}
}
