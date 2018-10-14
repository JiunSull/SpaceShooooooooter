using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public Rigidbody r;
	public float tumble;

	void Start () 
	{

		r.angularVelocity = Random.insideUnitSphere * tumble;
		
	}
	

}
