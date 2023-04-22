using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemigos: MonoBehaviour
{
    [Header ("ESTADISTICAS DE DAÑO")]
    [SerializeField] float daño;
    [SerializeField] float tiempoEntreDaño;

    private float tiempoSiguienteDaño;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño);
        }
    }
}
