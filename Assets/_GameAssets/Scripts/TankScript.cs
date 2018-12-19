using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour {

    public float tankForce = 50;
   /* public Vector3 PosPlayer;
	
    public static void Guardar_Posicion(Vector3 Posicion)
    {
        PlayerPrefs.SetFloat("x", Posicion.x);
        PlayerPrefs.SetFloat("y", Posicion.y);
        PlayerPrefs.SetFloat("z", Posicion.z);
    }

    public static Vector3 Cargar_Posicion()
    {
        Vector3 Posicion;
        Posicion.x = PlayerPrefs.GetFloat("x");
        Posicion.y = PlayerPrefs.GetFloat("y");
        Posicion.z = PlayerPrefs.GetFloat("z");
        return Posicion;
    }*/

	void Update () {
        //PosPlayer = GameObject.FindGameObjectWithTag("Tank").transform.position;
        transform.Translate(0, 0, 1 * tankForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Tank").transform.position = new Vector3 (108.03f, 4.17f, 84.81f);
        //GameObject.FindGameObjectWithTag("Tank").transform.rotation = new Vector3.Rotate (0);
    }
}
