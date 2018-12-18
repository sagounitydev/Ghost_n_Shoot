using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    public void alInicio(string Menu_Inicio)
    {
        SceneManager.LoadScene(Menu_Inicio);
    }
}
