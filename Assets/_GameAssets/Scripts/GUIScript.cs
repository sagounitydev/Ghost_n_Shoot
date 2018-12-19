using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    public Image prefabImagenVida;
    public GameObject panelVidas;
    public PlayerControllerScript pls;
    public Scrollbar BarraVida;
    public float maxEnergia = 100f;
    float restaEnergia;
    private int numeroVidas;
    
    //Image nuevaImage;
    Image[] imagenesVida;

    void Start() {

        restaEnergia = maxEnergia;
        BarraVida.size = restaEnergia / maxEnergia;
        
        numeroVidas = pls.GetVidas();
        imagenesVida = new Image[numeroVidas];

        for (int i = 0; i < imagenesVida.Length; i++) {
            imagenesVida[i] = Instantiate(prefabImagenVida, panelVidas.transform);
        }
    }
    
    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Enemy")) {
            restaEnergia -= col.GetComponent<ZombieScript>().HacerDanyo();
        }
    }

    public void RestarVida() {        
        numeroVidas = pls.GetVidas();
        for (int i = numeroVidas; i < imagenesVida.Length; i++) {
            imagenesVida[i].color = new Color32(160, 160, 160, 128);
        }
        /*
        for (int i = numeroVidas; i < imagenesVida.Length; i++) {
            if (imagenesVida[i] != null) {
                Destroy(imagenesVida[i].gameObject);
            }
        }
        */
    }
}
