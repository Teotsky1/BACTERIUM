using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;


public class SistemaDeVida : MonoBehaviour
{

    [Header ("STATS VIDA")]
    [SerializeField] float Maxhp = 10;
    [SerializeField] float hpActual;



    [Header ("INMUNIDAD")]
    public bool Inmunidad = false;
    [SerializeField] float tiempoInmortal = 0.5f;



    //public Text VidaText;

    private void Start()
    {
        hpActual = Maxhp;    
    }

    private void Update()
    {
        if (hpActual > Maxhp) hpActual = Maxhp;

        if (hpActual <= 0) Death();
        

        //INTERFAZ VIDA
        //VidaText.text = hpActual.ToString();
    }

    public void QuitarVida (float Daño)
    {
        if (Inmunidad) return;

        hpActual -= Daño;

        StartCoroutine(TiempoInmunidad());
    }

    public void Curar (float curacion)
    {
        hpActual += curacion;
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
