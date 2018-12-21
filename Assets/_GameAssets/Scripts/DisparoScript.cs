using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoScript : MonoBehaviour {

    [SerializeField] ParticleSystem psFogonazo;
    [SerializeField] Transform genPS;
    [SerializeField] Transform genCasquillo;
    [SerializeField] GameObject prefabCasquillo;
    [SerializeField] int forceCas = 100;

    [SerializeField] Animator playerAnim;
    
    public int damagePerShot = 10;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    //Particle gunParticles;
    LineRenderer gunLine;
    private AudioSource Disparando;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    private void Awake() {
        shootableMask = LayerMask.GetMask("Shootable");
        psFogonazo = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        Disparando = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    private void Start() {
        
    }

    void Update () {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            ParticleSystem ps = Instantiate(psFogonazo, transform.position, Quaternion.identity);
            ps.Play();

            playerAnim.SetBool("disparando", true);
            
            GameObject casquillo = Instantiate(prefabCasquillo, genCasquillo.transform.position, genCasquillo.transform.rotation);
            casquillo.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forceCas);

            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime) {
            DisableEffects();
        }

        if (Input.GetButtonUp("Fire1")) {
            playerAnim.SetBool("disparando", false);            
            Disparando.Stop();

        }      
	}

    public void DisableEffects() {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot() {
        timer = 0f;

        Disparando.Play();

        gunLight.enabled = true;

        //psFogonazo.Stop();
        //psFogonazo.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null){
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
