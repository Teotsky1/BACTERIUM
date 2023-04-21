using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoAJugador : MonoBehaviour
{
    [Header("DAÑO")]
    [SerializeField] float daño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SistemaDeVida>() != null) 
        {
            other.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño); 
        }
        if (other.CompareTag("Player"))
            Destroy(other.gameObject);
    }

    
}
