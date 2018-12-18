using UnityEngine;
using System.Collections;

public class DestroybyContact : MonoBehaviour {
	public GameObject explode; // ตัวแปรทำระเบิด
	public GameObject playerexplode; // แสงระเบิดผู้เล่น

	public int values;

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
		//---------------------------------------------------------
		if (other.tag == "Boundary") {
			return;
		}


		//---------------------------------------------------------
		if (other.tag == "Player") {
			Instantiate (explode, other.transform.position, other.transform.rotation);
			Instantiate (playerexplode, other.transform.position, other.transform.rotation);
			gameController.GameOver ();

			Destroy (gameObject); // ลบตัวเอง
			Destroy (other.gameObject); // ลบของที่ชน
		}

		//-------------------------------------------------------
		if (other.tag == "Bolts") {
			Instantiate (explode, other.transform.position, other.transform.rotation);
			Destroy (gameObject); // ลบตัวเอง
			Destroy (other.gameObject); // ลบของที่ชน
			gameController.AddScore ( values );
		}

		if (other.tag == "SuperBolts") {
			Instantiate (explode, other.transform.position, other.transform.rotation);
			Destroy (gameObject); // ลบตัวเอง
			gameController.AddScore ( values );
		}

	}

}

