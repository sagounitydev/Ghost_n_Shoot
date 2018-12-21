using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int Score;

    PlayerControllerScript text;

    private void Awake()
    {
        text = GetComponent<PlayerControllerScript>();
        Score = 0;
    }

    private void Update()
    {
       //text.Score = "Score: " + Score;
    }
}
