using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastScript : MonoBehaviour {
    Transform zombie;
    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField] float hacerDanyo = 15f;
    float damageValue;

    int suVida = 30;
    int suDanyo = 15;

    private Animator anim;

    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
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

    public float HacerDanyo()
    {

        suVida -= suDanyo;
        return damageValue = 15.0f;
    }

    private void danyo()
    {
        bool queDanyo = true;
        anim.SetBool("herido", queDanyo);
    }

    private void estasMuerto()
    {
        bool unoMenos = true;
        anim.SetBool("muerto", unoMenos);
        Destroy(this.gameObject, 4f);
    }
}
