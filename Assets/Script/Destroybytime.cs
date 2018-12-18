using UnityEngine;
using System.Collections;

public class Destroybytime : MonoBehaviour {
	public float liftTime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, liftTime); // ถึงเวลาแล้วจะทำให้หายไป
	}
	

}
