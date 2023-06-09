using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SistemaDeVida : MonoBehaviour
{

    [Header ("STATS VIDA")]
    [SerializeField] float Maxhp = 5;
    [SerializeField] float hpActual;



    [Header ("INMUNIDAD")]
    public bool Inmunidad = false;
    [SerializeField] float tiempoInmortal = 0.5f;


    public TMP_Text VidaText;
    public GameObject[] vidas;


    public GameObject PlayerDash;



    [Header("Puntos")]
    [SerializeField] public float puntos;



    private void Start()
    {
        hpActual = Maxhp;    
    }

    private void Update()
    {
        if (hpActual > Maxhp) hpActual = Maxhp;


        if (hpActual <= 0) Death();
        
        
        

        //INTERFAZ VIDA
        VidaText.text = ("Points ")+puntos.ToString();
        
        
    }

    public void QuitarVida (float Da�o)
    {
        if (Inmunidad) return;

        hpActual -= Da�o;
        

        StartCoroutine(TiempoInmunidad());

        if (hpActual < 5) vidas[4].SetActive(false);

        if (hpActual < 4) vidas[3].SetActive(false);

        if (hpActual < 3) vidas[2].SetActive(false);

        if (hpActual < 2) vidas[1].SetActive(false);

        if (hpActual < 1) vidas[0].SetActive(false);
    }

    public void Curar (float curacion)
    {

        if (hpActual > Maxhp) return;


        hpActual += curacion;

        if (hpActual >= 2) vidas[1].SetActive(true);

        if (hpActual >= 3) vidas[2].SetActive(true);

        if (hpActual >= 4) vidas[3].SetActive(true);

        if (hpActual >= 5) vidas[4].SetActive(true);

    }

    public void Death()
    {
       

        Destroy(this.gameObject);
    }


     IEnumerator TiempoInmunidad()
     {
        Inmunidad = true;
        yield return new WaitForSeconds(tiempoInmortal);
        Inmunidad = false;
     }



    
}
