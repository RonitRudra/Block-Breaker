using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public static int breakableBricks = 0;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager LVM;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable =this.tag == "Breakable";
		if(isBreakable){
			breakableBricks++;
			//Debug.Log(breakableBricks.ToString());
		}
		
		timesHit = 0;
		LVM = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		}
	
	void OnCollisionEnter2D (Collision2D collison){
		AudioSource.PlayClipAtPoint(crack,transform.position);
		if (isBreakable){
		HandleHits();
		}
	}
	
	void SimulateWin(){
		LVM.LoadNextLevel();
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	void HandleHits(){
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit>=maxHits) {
			breakableBricks--;
			LVM.BrickDestroyed();
			//Debug.Log(breakableBricks.ToString());
			GameObject smokepuff = Instantiate(smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
			smokepuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
			
		} else {
			LoadSprites();
		}
	}
}
