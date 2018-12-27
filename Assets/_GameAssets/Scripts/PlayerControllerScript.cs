using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControllerScript : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator animator;
    private CharacterController characterController;
    AudioSource playerAudio;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    private Rigidbody rb;

    [SerializeField] float moveSpeed = 4f;

    //UI
    int vidasMaximas = 4;
    [SerializeField] int vidas;
    [SerializeField] Text Score;
    [SerializeField] GUIScript uiScript;
    //[SerializeField] public static int salud = 100;
    //[SerializeField] public static int saludMaxima = 100;

    [SerializeField] int puntos = 0;
    //FIN UI

    [System.Serializable]
    public class AnimationSettings
    {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "Strafe";
        public string groundBool = "isGrounded";
        public string jumpBool = "isJumping";
        //public string disparoBool = "disparando";
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
    //bool disparando;

    //UI
    private void Awake() {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;

        /*vidas = vidasMaximas;
        salud = saludMaxima;*/ 
     }

    public int GetVidas() {
        return this.vidas;
    }
    //FIN UI

    private void Start()
    {
        Score.text = "Score: " + puntos.ToString();        
        SetupAnimator();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ApplyGravity();
        isGrounded = characterController.isGrounded;

        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        animator.SetTrigger("PlayerHerido");

        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        animator.SetTrigger("PlayerMuerto");

        playerAudio.clip = deathClip;

        playerAudio.Play();

        characterController.enabled = false;
        //playerShooting.enabled = false;
    }



    private void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(rotation, 0, translation);
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
