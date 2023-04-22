using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemigos: MonoBehaviour
{
    [Header ("ESTADISTICAS DE DA�O")]
    [SerializeField] float da�o;
    [SerializeField] float tiempoEntreDa�o;

    private float tiempoSiguienteDa�o;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SistemaDeVida>().QuitarVida(da�o);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<SistemaDeVida>().QuitarVida(da�o);
        }
    }
}
