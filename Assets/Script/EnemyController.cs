using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed;
	GameObject player;
	private Rigidbody rb;
	public float tilt;
	public float waitTime;
	public float RepeatTime;



	public GameObject enemybolts;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating( /* "ชื่อฟังก์ชัน" */ "OnShooting" , /*เวลาที่เริ่ม*/ waitTime, /*เวลาในการเรียกซ้ำ*/ RepeatTime );
	}

	void OnShooting(){
		Instantiate (enemybolts, transform.position, Quaternion.identity);
		GetComponent<AudioSource> ().Play();
	}

	void FixedUpdate () {
	
		if(player != null){
			float moveX = 0;

			// ถ้าผู้เล่นมีแกน x มากกว่าศัตรู
			if (Mathf.Round (player.transform.position.x) > Mathf.Round (transform.position.x)) {
				moveX = 1f;
			} else {
				moveX = -1f;
			}

			rb.velocity = new Vector3 (moveX, 0f, -1f) * speed;
			rb.rotation = Quaternion.Euler (0f, 180f, rb.velocity.x * tilt);
		}
	}
}
