using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public int hazardcount;
	public float spawnwait;
	public Vector3 Spawnvalues;
	public int wavewaits;
	public int StartWait;

	public Text GameoverText;
	public Text RestartText;
	public Text ScoreText;

	private int score;

	private bool Gameover;
	private bool restart;

	public GameObject Enemy;
	public float waitTime;
	public float RepeatTime;

	void Start () {
		score = 0;
		Gameover = false;
		restart = false;

		GameoverText.text = "";
		RestartText.text = "";

		UpdateScore();

		StartCoroutine (SpawnWaves ());

		InvokeRepeating ("SpawnEnemy", waitTime, RepeatTime);
	}

	void SpawnEnemy(){
		Vector3 spawnPosition = new Vector3(Random.Range(-Spawnvalues.x , Spawnvalues.x),Spawnvalues.y,Spawnvalues.z);
		Instantiate (Enemy, spawnPosition, Quaternion.identity);
	}

	void UpdateScore(){
		ScoreText.text = "Score : " + score.ToString();
	}

	public void AddScore(int newScoreValues){
		score += newScoreValues;
		UpdateScore ();
	}

	public void GameOver()
	{
		GameoverText.text = "Game Over";
		Gameover = true;
	}

	void Update(){
		
		if (Gameover) {
			
			restart = true;
			RestartText.text = "Press 'R' for restart.";

		}

		if (restart) {
			
			if (Input.GetKeyDown (KeyCode.R)) {
				
				Application.LoadLevel (Application.loadedLevel);

			} else if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit();
			}
		}
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (StartWait);

		while(true)
		{
			for(int i = 0; i < hazardcount ; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-Spawnvalues.x , Spawnvalues.x),Spawnvalues.y,Spawnvalues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnwait);
			}
			yield return new WaitForSeconds (wavewaits);
		}

	}
}
