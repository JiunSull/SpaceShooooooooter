using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
	public Rigidbody rb;

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public GameObject[] shotSpawn;
	public float fireRate;

	private float nextFire;
	AudioSource audioData;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	void Update ()
	{
		if (Input.GetMouseButton(0) && Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			//GameObject clone = 
			for (int i = 0; i < shotSpawn.Length; i++) {
				Instantiate (shot, shotSpawn[i].transform.position, shotSpawn [i].transform.rotation);
			}
			audioData = GetComponent<AudioSource>();
			audioData.Play();

		}


	}


	void FixedUpdate ()
	{
		float moverHorizontal = Input.GetAxis ("Horizontal");
		float moverVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moverHorizontal, 0.0f, moverVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);



		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);
	}
}