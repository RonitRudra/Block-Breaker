using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableBricks = 0;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	public void BrickDestroyed(){
		if (Brick.breakableBricks<=0){
			LoadNextLevel();
		}
	}
}