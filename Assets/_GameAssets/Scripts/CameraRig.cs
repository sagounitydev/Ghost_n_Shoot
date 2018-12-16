using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public Transform target;
    public bool autoTargetPlayer;
    public LayerMask wallLayers;

    public enum Shoulder
    {
        Right, Left
    }

    public Shoulder shoulder;

    [System.Serializable]
    public class CameraSettings
    {
        [Header("- Positioning-")]
        public Vector3 camPositionOffsetLeft;
        public Vector3 camPositionOffsetRight;

        [Header("-Camera Options-")]
        public float mouseXSensibility = 5.0f;
        public float mouseYSensibility = 5.0f;
        public float minAngle = -30.0f;
        public float maxAngle = 70.0f;
        public float rotationSpeed = 5.0f;

        [Header("-Zoom-")]
        public float fieldOfView = 70.0f;
        public float zoomFieldOfView = 30.0f;
        public float zoomSpeed = 3.0f;

        [Header("-Visual Options-")]
        public float hidMeshWhenDistance = 0.5f;
    }

    [SerializeField]
    CameraSettings cameraSettings;

    [System.Serializable]
    public class InputSettings
    {
        public string verticalAxis = "Vertical";
        public string horizontalAxis = "Horizontal";
        public string aimButton = "Fire2";
        public string switchShoulderButton = "Fire4";
    }

    [SerializeField]
    public InputSettings input;

    [System.Serializable]
    public class MovementSettings
    {
        public float movementLerpSpeed = 5.0f;
    }

    [SerializeField]
    public MovementSettings movement;

    Transform pivot;
    Camera mainCamera;
    float newX = 0.0f;
    float newY = 0.0f;

    void Start () {
        mainCamera = Camera.main;
        pivot = transform.GetChild(0);
	}

	void Update () {
		
	}
}
