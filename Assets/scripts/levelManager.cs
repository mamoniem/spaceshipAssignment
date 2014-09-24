using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

	public static levelManager instance;

	public GUIText score;
	public GUIText stars;
	public GUIText lifes;

	public int scoreValue;
	public int starsValue;
	public int lifesValue;

	public GameObject enemyPrefab;
	public GameObject enemisSpawnPoint;
	public GameObject enemyGroupHolder;

	public int enemiesCount;
	public float enemiesInterval;
	public float enemiesTimer;
	public float enemiesSwarmSpeed;

	public bool enemiesInstanced;

	public float enemiesSpeed;

	public GameObject starPrefab;

	void Awake(){
		instance = this;
		scoreValue = 0;
		starsValue = 0;
		lifesValue = 5;
		enemiesInterval = 0.7f;
		enemiesInstanced = false;
		enemiesSpeed = 0.1f;

	}
	// Use this for initialization
	void Start () {
		changeLifes(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (lifesValue < 0){
			Application.LoadLevel ("resultsScene");
			PlayerPrefs.SetInt("Score", scoreValue);
		}

		//rotate the enemies
		enemisSpawnPoint.gameObject.transform.Rotate (1*-Vector3.up * enemiesSwarmSpeed * Time.deltaTime);

		if (enemisSpawnPoint.gameObject.transform.childCount == 0){
			enemiesInstanced = false;
		}else{

		}

		if (!enemiesInstanced && enemisSpawnPoint.gameObject.transform.childCount <= 0){
			StartCoroutine (checkAndAddEnemies());
		}
	}

	//update UI values
	public void addScore(int val){
		scoreValue += val;
		score.text = scoreValue.ToString();
	}

	public void addStars(int val){
		starsValue += val;
		stars.text = starsValue.ToString();
	}

	public void changeLifes(int val){
		lifesValue += val;
		lifes.text = lifesValue.ToString();
	}

	IEnumerator checkAndAddEnemies(){
		enemiesInstanced = true;
		//pick a random amount of enemies for ach wave of them
		enemiesCount = Random.Range (8, 15);

		Instantiate (starPrefab.gameObject, enemisSpawnPoint.transform.position, enemyGroupHolder.transform.rotation);

		for (int c=0; c<enemiesCount; c++){
			GameObject anEnemy;
			anEnemy = Instantiate (enemyPrefab.gameObject,
			                       new Vector3(enemisSpawnPoint.transform.position.x, enemisSpawnPoint.transform.position.y, enemisSpawnPoint.transform.position.z+2.0f),
			                       enemyGroupHolder.transform.rotation)
				as GameObject;
			//anEnemy.transform.localPosition.z += 5;
			anEnemy.transform.parent = enemisSpawnPoint.gameObject.transform;


			yield return new WaitForSeconds (enemiesInterval);
		}

		updateAttributes();
	}

	void updateAttributes(){
		enemiesSpeed += 0.1f;
	}
}
