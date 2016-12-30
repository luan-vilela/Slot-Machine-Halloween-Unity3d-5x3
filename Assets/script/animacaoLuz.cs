using UnityEngine;
using System.Collections;

public class animacaoLuz : MonoBehaviour {

	Animator anim;
	bool liberado;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rodarRoleta5.tempo == 0){
			if(liberado){
			liberado = !liberado;
			anim.SetBool("girando",false);
			}
		}
		else{
			if(!liberado){
				liberado = !liberado;
				anim.SetBool("girando",true);
			}
		}
	}
}
