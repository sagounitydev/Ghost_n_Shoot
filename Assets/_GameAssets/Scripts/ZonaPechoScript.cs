using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaPechoScript : MonoBehaviour {

    [SerializeField] Animator animZombie;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.CompareTag ("Bala")) {
            animZombie.SetBool("herido", true);
            print("ME HAS DADO");

        }
    }
}
