using UnityEngine;
using System.Collections;

public class basicBullet : MonoBehaviour {

	public float bulletSpeed;
	public float lifeTime;

	public AudioClip expossion;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (lifeTime);
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward*bulletSpeed*Time.deltaTime);
	}

	void OnTriggerEnter (Collider col){
		// an enemy adds 15
		if (col.gameObject.tag == "enemy"){
			levelManager.instance.addScore(15);
			this.audio.PlayOneShot(expossion);
			Destroy(col.gameObject);
			Destroy (this.gameObject);
		}

		// a bomb adds 5
		if (col.gameObject.tag == "bomb"){
			levelManager.instance.addScore(5);
			this.audio.PlayOneShot(expossion);
			Destroy(col.gameObject);
			Destroy (this.gameObject);
		}
	}
}
