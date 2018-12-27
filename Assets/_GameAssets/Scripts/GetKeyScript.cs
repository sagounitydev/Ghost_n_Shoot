using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyScript : MonoBehaviour {

    [SerializeField] ParticleSystem psStars;
    
    void Awake() {
        psStars = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider collider) {
        ParticleSystem ps = Instantiate(psStars, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(this.gameObject);
    }
}
