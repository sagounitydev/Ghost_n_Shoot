using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour {

    public float tankForce = 50;

	void Start () {
		
	}
	
	void Update () {
        transform.Translate(0, 0, 1 * tankForce * Time.deltaTime);
    }
}
