using UnityEngine;
using System.Collections;

public class EnemyBoltController : MonoBehaviour {
	
	public GameObject playerexplode; // แสงระเบิดผู้เล่น
	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		if(gameControllerObject == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "Player") {
			Instantiate (playerexplode, other.transform.position, other.transform.rotation);
			gameController.GameOver ();

			Destroy (gameObject); // ลบตัวเอง
			Destroy (other.gameObject); // ลบของที่ชน
		}


	}
}


