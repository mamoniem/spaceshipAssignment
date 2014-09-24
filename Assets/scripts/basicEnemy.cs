using UnityEngine;
using System.Collections;

public class basicEnemy : MonoBehaviour {

	public float enemySpeed;
	public GameObject bombPrefab;

	public AudioClip explossion;
	public AudioClip shootBomb;

	// Use this for initialization
	void Start () {
		enemySpeed = levelManager.instance.enemiesSpeed;
		InvokeRepeating("addBomb", 0.1f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward*enemySpeed*Time.deltaTime);
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

	void addBomb (){
		if (this.transform != null){
			Instantiate (bombPrefab.gameObject, transform.position, transform.rotation);
			this.audio.PlayOneShot(shootBomb);
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "player"){
			levelManager.instance.changeLifes (-1);
			this.audio.PlayOneShot(explossion);
			Destroy (this.gameObject);
		}
	}
}
