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

    private AudioSource Disparando;

    //public float theDistance;
    //public float maxDistance;

    private void Start() {
        Disparando = GetComponent<AudioSource>();
    }

    void Update () {  

        if (Input.GetButtonDown("Fire1"))
        {            
            Disparando.Play();
            ParticleSystem ps = Instantiate(psFogonazo, transform.position, Quaternion.identity);
            ps.Play();

            playerAnim.SetBool("disparando", true);
            
            GameObject casquillo = Instantiate(prefabCasquillo, genCasquillo.transform.position, genCasquillo.transform.rotation);
            casquillo.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forceCas);

            //RaycastHit hit;
            //int force;
            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

            /*if(Physics.Raycast(transform.position,(forward), out hit))
            {
                force = hit.distance;
                if(theDistance < maxDistance)
                {
                    //_enemyDamage.meHasDado();
                }
            }*/
        }

        if (Input.GetButtonUp("Fire1")) {
            playerAnim.SetBool("disparando", false);            
            Disparando.Stop();

        }
	}
}
