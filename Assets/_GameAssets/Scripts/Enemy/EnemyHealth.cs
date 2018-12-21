using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;    

    void Awake() {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }
    
    public void TakeDamage (int amount, Vector3 hitPoint) {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        anim.SetTrigger("herido");

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0) {
            Death();
        }
    }

    void Death() {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("muerto");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

     public void StartSinking() {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        ScoreManager.Score += scoreValue;
        Destroy(gameObject, 4f);
    }
}
