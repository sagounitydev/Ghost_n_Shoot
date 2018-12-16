using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour {

    Transform zombie;
    NavMeshAgent nav;

    private Animator anim;

	void Start () {
        zombie = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool aPorEl = true;
        anim.SetBool("corriendo", aPorEl);
        nav.SetDestination(zombie.position);
    }
    private void OnTriggerExit(Collider other)
    {
        bool aPorEl = false;
        anim.SetBool("corriendo", aPorEl);

    }
}
