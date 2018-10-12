using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {

	public Player player;

	public GameObject enemyPrefab;

	public float enemyCountdown = 2f;

	private float enemyTimer;

	public float minimumEnemyCountdown = 1f;

	public Text gameText;

	private float gameTimer;
	private bool isGameOver;

	void Start () {
		
	}
	

	void Update () {

		if (Input.GetKeyDown ("r")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}


		if (player != null) {
			gameTimer += Time.deltaTime;
			gameText.text = "Days: " + Mathf.Floor (gameTimer);
		} else {
			if (!isGameOver) {
				isGameOver = true;
				Debug.Log ("heybaby!");
				gameText.text += "\nGame over, press R to restart";
			}
		}
		enemyTimer -= Time.deltaTime;
		if (enemyTimer <= 0  && player != null) {
			enemyTimer = enemyCountdown;

			enemyCountdown *= 0.9f;
			if (enemyCountdown < minimumEnemyCountdown) {
				enemyCountdown = minimumEnemyCountdown;
			};

			Vector3[] spawnPositions = new Vector3[] {
				new Vector3 (6, -6, 0),
				new Vector3 (6, 6, 0),
				new Vector3 (-6, 6, 0),
				new Vector3 (-6, -6, 0)
			};

			foreach (Vector3 spawnPosition in spawnPositions) {
				GameObject enemyObject = Instantiate (enemyPrefab);
				enemyObject.transform.position = spawnPosition;
				enemyObject.transform.SetParent (this.transform);

				Enemy enemy = enemyObject.GetComponent<Enemy> ();
				enemy.movementDirection = (player.transform.position - spawnPosition).normalized;
			}
		}
	}
}
