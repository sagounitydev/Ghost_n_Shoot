using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour {

    Transform zombie;
    PlayerControllerScript playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    float damageValue;

    int suVida = 30;
    int suDanyo = 15;

    private Animator anim;

    private void Awake() {
        zombie = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = zombie.GetComponent<PlayerControllerScript>();
        enemyHealth = GetComponent<EnemyHealth>();
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

    private void Update() {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
            nav.SetDestination(zombie.position);
        } else {
            nav.enabled = false;
        }
    }
}
