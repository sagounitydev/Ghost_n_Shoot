using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour {

    Transform player;
    PlayerControllerScript playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    float damageValue;

    int suVida = 30;
    int suDanyo = 15;

    private Animator anim;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerControllerScript>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.transform.gameObject.tag == "Player") {
            bool aPorEl = true;
            anim.SetBool("corriendo", aPorEl);
            nav.SetDestination(player.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player") {
            bool aPorEl = false;
            anim.SetBool("corriendo", aPorEl);
        }
    }

    private void Update() {
        if(enemyHealth.currentHealth <= 0 || playerHealth.currentHealth <= 0) {
            nav.enabled = false;
        } 
    }
}
