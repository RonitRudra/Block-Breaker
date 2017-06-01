using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager LVM;
	
	void Start (){
		LVM = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter2D (Collider2D collider) {
		//Debug.Log("Trigger");
		LVM.LoadLevel("Lose");
	}
	
	//void OnCollisionEnter2D(Collision2D collision) {
	//	Debug.Log ("Collision");
	//}
}
