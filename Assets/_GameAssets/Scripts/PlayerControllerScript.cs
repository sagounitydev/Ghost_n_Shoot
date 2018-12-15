using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour {

    Animator animator;
    /*float adelante = 0.1f;
    float haciaAtras = -0.1f;*/
    private CharacterController characterController;

    [SerializeField] float moveSpeed = 400;
       
    private void Awake() {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update () {
         var horizontal = Input.GetAxis("Horizontal");
         var vertical = Input.GetAxis("Vertical");

        Move(horizontal,vertical);

         var movement = new Vector3(horizontal, 0, vertical);

         characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
     }

    private void Move(float horizontal, float vertical)
    {
        animator.SetFloat("MovX", horizontal);
        animator.SetFloat("MovY", vertical);       
    }
}
