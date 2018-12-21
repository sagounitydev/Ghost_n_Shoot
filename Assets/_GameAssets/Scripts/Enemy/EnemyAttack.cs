using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttack = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerControllerScript playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerControllerScript>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other) {
        if(other.gameObject == player) {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            playerInRange = false;
        }
    }
	
	void Update () {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttack && playerInRange && enemyHealth.currentHealth > 0) {
            Attack();
        }

        if(playerHealth.currentHealth <= 0) {
            anim.SetTrigger("PlayerMuerto");
        }
	}

    void Attack() {
        timer = 0f;

    }
}
