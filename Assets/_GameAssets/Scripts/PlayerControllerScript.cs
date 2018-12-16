﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControllerScript : MonoBehaviour {

    Animator animator;
    private CharacterController characterController;

    private Rigidbody rb;

    [SerializeField] float moveSpeed = 3f;

    [System.Serializable]
    public class AnimationSettings
    {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "Strafe";
        public string groundBool = "isGrounded";
        public string jumpBool = "isJumping";
    }

    [SerializeField]
    public AnimationSettings animations;

    [System.Serializable]
    public class PhysicsSettings
    {
        public float gravityModifier = 9.81f;
        public float baseGravity = 50.0f;
        public float resetGravityValue = 1.2f;
    }

    [SerializeField]
    public PhysicsSettings physics;

    [System.Serializable]
    public class MovementSettings
    {
        public float jumpSpeed = 6;
        public float jumpTime = 0.25f;
    }

    [SerializeField]
    public MovementSettings movement;

    bool jumping;
    bool resetGravity;
    float gravity;
    bool isGrounded = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupAnimator();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ApplyGravity();
        isGrounded = characterController.isGrounded;

        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(rotation, 0, translation);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
    }

    public void Animate(float forward, float strafe)
    {
        animator.SetFloat(animations.verticalVelocityFloat, forward);
        animator.SetFloat(animations.horizontalVelocityFloat, strafe);
        animator.SetBool(animations.groundBool, isGrounded);
        animator.SetBool(animations.jumpBool, jumping);
    }

    public void Jump()
    {
        if (jumping)
           return;

        if (isGrounded)
        {
            jumping = true;
            StartCoroutine(StopJump());
        }        
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(movement.jumpTime);
        jumping = false;
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            if (!resetGravity)
            {
                gravity = physics.resetGravityValue;
                resetGravity = true;
            }
            gravity += Time.deltaTime * physics.gravityModifier;
        } else
        {
            gravity = physics.baseGravity;
            resetGravity = false;
        }

        Vector3 gravityVector = new Vector3();

        if (!jumping)
        {
            gravityVector.y -= gravity;
        }
        else
        {
            gravityVector.y = movement.jumpSpeed;
        }
        characterController.Move(gravityVector * Time.deltaTime);
    }

    void SetupAnimator()
    {
        Animator[] animators = GetComponentsInChildren<Animator>();

        if(animators.Length > 0)

        {
            for(int i = 0; i < animators.Length; i++)
            {
                Animator anim = animators[i];
                Avatar av = anim.avatar;
                if(anim != animator)
                {
                    animator.avatar = av;
                    Destroy(anim);
                }
            }
        }
    }
}
