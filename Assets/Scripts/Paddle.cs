using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlepos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
		float mouse_pos = Input.mousePosition.x/Screen.width*16;
		paddlepos.x = Mathf.Clamp(mouse_pos,0.5f,15.5f);
		this.transform.position = paddlepos;
	}
}
