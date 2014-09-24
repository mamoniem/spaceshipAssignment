using UnityEngine;
using System.Collections;

public class baseStar : MonoBehaviour {

	private Vector3 destination ;
	public AudioClip collectStar;

	// Use this for initialization
	void Start () {
		destination = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
	}
	// Update is called once per frame
	void Update () {
		this.transform.Translate (destination*1.5f*Time.deltaTime);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "player"){
			levelManager.instance.addStars(1);
			this.audio.PlayOneShot(collectStar);
			Destroy (this.gameObject);
		}
	}
}
