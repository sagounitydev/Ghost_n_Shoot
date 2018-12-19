using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int puntos;

    PlayerControllerScript text;

    private void Awake()
    {
        text = GetComponent<PlayerControllerScript>();
        puntos = 0;
    }

    private void Update()
    {
        //text.puntos = "Score: " + puntos;
    }
}
