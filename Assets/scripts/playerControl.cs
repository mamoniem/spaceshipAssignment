using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public GameObject child;
	public float speed = 120.0f;

	public float touchStartPos;
	public float touchEndPos;
	public float swipeValue;

	public GameObject[] shootersPoints;
	public GameObject bulletPrefab;

	public AudioClip firing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(child.transform.position, this.transform.position, Color.red);



		#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
		//touch input
		if (Input.GetTouch(0).phase == TouchPhase.Began){
			touchStartPos = Input.GetTouch(0).position.x;
		}
		if (Input.GetTouch(0).phase == TouchPhase.Ended){
			touchEndPos = Input.GetTouch(0).position.x;
			swipeValue = touchEndPos-touchStartPos;
		}
		if (swipeValue >0){
			this.gameObject.transform.Rotate (1*-Vector3.up * speed * Time.deltaTime);
		}else if (swipeValue <0){
			this.gameObject.transform.Rotate (-1*-Vector3.up * speed * Time.deltaTime);
		}

		#else
		//keyboard input
		if (Input.GetAxis("Horizontal") != 0){
			this.gameObject.transform.Rotate (Input.GetAxis("Horizontal")*-Vector3.up * speed * Time.deltaTime);
		}

		//mouse input
		if (Input.GetAxis("Mouse X") != 0){
			this.gameObject.transform.Rotate (Input.GetAxis("Mouse X")*-Vector3.up * speed * Time.deltaTime);
		}

		if (Input.GetButtonDown("Fire1")){
			for (int c=0; c<shootersPoints.Length; c++){
				Instantiate (bulletPrefab, shootersPoints[c].gameObject.transform.position,  shootersPoints[c].gameObject.transform.rotation);
			}
			this.audio.PlayOneShot(firing);
		}
		#endif


	}
}
