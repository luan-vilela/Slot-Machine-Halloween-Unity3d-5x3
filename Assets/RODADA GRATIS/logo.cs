using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {
	public GameObject logoImagem, texto;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		if(rodarRoleta5.tempo == 0){
			for(float i = logoImagem.transform.position.z; i <= -4; i+=0.1f){
				logoImagem.transform.position = new Vector3(logoImagem.transform.position.x,logoImagem.transform.position.y,i);
			}
		}
	}

}
