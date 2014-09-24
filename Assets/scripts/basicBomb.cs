using UnityEngine;
using System.Collections;

public class basicBomb : MonoBehaviour {

	private Vector3 destination ;
	public AudioClip explossion;

	// Use this for initialization
	void Start () {
		destination = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
	}
	// Update is called once per frame
	void Update () {
		this.transform.Translate (destination*1.5f*Time.deltaTime);
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "player"){
			levelManager.instance.changeLifes (-1);
			//this.audio.PlayOneShot(explossion);
			Destroy (this.gameObject);
		}
	}
}
