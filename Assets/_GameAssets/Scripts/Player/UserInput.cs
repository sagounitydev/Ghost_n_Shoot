using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

    PlayerControllerScript characterMove;

    /*public float Horizontal;
    public float Vertical;*/

    [System.Serializable]
    public class InputSettings
    {
        public string verticalAxis = "Vertical";
        public string horizontalAxis = "Horizontal";
        public string jumpButton = "Jump";
    }
    [SerializeField]
    InputSettings input;
    
    [System.Serializable]
    public class OtherSettings
    {
        public float lookSpeed = 5.0f;
        public float lookDistance = 10.0f;
        public bool requireInputForTurn = true;
    }
    [SerializeField]
    public OtherSettings other;

    Camera mainCam;

	void Start () {
        characterMove = GetComponent<PlayerControllerScript>();
        mainCam = Camera.main;
    }

	void Update () {
        if (characterMove)
        {
            characterMove.Animate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

            if (Input.GetButtonDown("Jump"))
            {
                characterMove.Jump();
            }
        }
        if (mainCam)
        {
            if(other.requireInputForTurn)
            {
                if(Input.GetAxis(input.horizontalAxis) !=0 || Input.GetAxis(input.verticalAxis) !=0)
                {
                    CharacterLook();
                }
            }
            else
            {
                CharacterLook();
            }
        }
	}

    //Hacemos que el Player mire siempre hacia adelante
    void CharacterLook()
    {
        Transform mainCamT = mainCam.transform;
        Vector3 mainCamPos = mainCamT.position;
        Vector3 lookTarget = mainCamPos + (mainCamT.forward * other.lookDistance);
        Vector3 thisPos = transform.position;
        Vector3 lookDir = lookTarget - thisPos;
        Quaternion lookRot = Quaternion.LookRotation(lookDir);
        lookRot.x = 0;
        lookRot.z = 0;

        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * other.lookSpeed);
        transform.rotation = newRotation;
    }
}
