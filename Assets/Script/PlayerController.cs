using UnityEngine;
using System.Collections;

[System.Serializable]
public class boundary
{
	public float xMin,xMax,zMin,zMax;	
}


public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public boundary _boundary;
	public float titl;

	public float firerate; // รั้งการยิง
	private float nextfire; // เวลายิงต่อไปได้
	public float firerate2; // รั้งการยิง
	private float nextfire2; // เวลายิงต่อไปได้

	public GameObject shot; // กระสุน
	public GameObject shot2; // กระสุน
	public Transform shotspawn; // จุดกำเนิดกระสุน

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		//rb.AddForce (movement * speed); // ใส่แรง ถ้าหยุดกดตัวละครไม่หยุด

		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, _boundary.xMin, _boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, _boundary.zMin, _boundary.zMax)); // กำหนดไม่ให้เคลื่อนที่ไปมากกว่าที่ๆกำหนด

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x*(-titl)); // ใช้หมุนตัวละคร
	}

	void Update() {
		// ใช้กดยิง
		if(Input.GetButton("Fire1") && Time.time > nextfire) {
			nextfire = Time.time + firerate;
			Instantiate (shot, shotspawn.position, shotspawn.rotation);
			GetComponent<AudioSource> ().Play();
		}
		else if(Input.GetButton("Fire2") && Time.time > nextfire2) {
			nextfire2 = Time.time + firerate2;
			Instantiate (shot2, shotspawn.position, shotspawn.rotation);
			GetComponent<AudioSource> ().Play();
		}


	}
}
