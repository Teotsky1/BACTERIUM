using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TabKey : MonoBehaviour
{
    private bool ya;
    private bool yapuedecongelar;
    private bool yapuedeenvenenar;

    private void Start()
    {
        ya = false;
        yapuedecongelar = false;

    }
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Tab))
        {
            if ( yapuedecongelar == true)
            {
                gameObject.GetComponent<DisparoJugador>().CambioDebala = 1;

                ya = true;
            }
            else if ( ya == true )
            {
                gameObject.GetComponent<DisparoJugador>().CambioDebala = 0;

            }
            else
            {
                Debug.Log("todavia no hay otra habilidad");
            }
        }
    }
    public void ActivarCongelamiento(bool puede)
    {
        yapuedecongelar = puede;
    }
    
        
    
}