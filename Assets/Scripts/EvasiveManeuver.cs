using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    public Vector2 startWait;

    private float targetManeuver;

	// Use this for initialization
	void Start () {
        StartCoroutine(Evade());
	}


    IEnumerator Evade ()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range();
            yield return new WaitForSeconds ();
            targetManeuver = 0;
            yield return new WaitForSeconds();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
