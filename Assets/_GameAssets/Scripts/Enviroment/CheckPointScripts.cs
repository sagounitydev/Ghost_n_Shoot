using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScripts : MonoBehaviour {

    /*private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Player") {
            PlayerControllerScript.StorePosition(collision.gameObject.transform.position);
            Destroy(this.gameObject);
        }
    }

    /* public Vector3 check1;
     public Vector3 check2;

     private void Awake() {
         if (PlayerPrefts.GetInt("Checkpoints") == 1){
             this.transform.position = check1;
         }
         if (PlayerPrefts.GetInt("Checkpoints") == 2){
             this.transform.position = check2;
         }
     }

     void Start () {

     }

     void Update () {

     }

     private void OntriggerEnter(Collider other) 
     {
         if (other.gameObject.tag == "check1") {
             PlayerPrefts.SetInt("Checkpoints", 1);
         }

         if (other.gameObject.tag == "check2") {
             PlayerPrefs.SetInt("Checkpoints", 2);
         }
     }*/

}
