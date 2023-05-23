using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurarJugador : MonoBehaviour
{
    [SerializeField] float Curacion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<SistemaDeVida>().Curar(Curacion);

            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        Destroy(this.gameObject , 9f);
    }
}
