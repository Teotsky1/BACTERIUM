using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AumentoFireRate : MonoBehaviour
{
    [SerializeField] public float ChangeParameter;


    private void Update()
    {
        Destroy(gameObject, 12f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DisparoJugador>() != null)
        {
            collision.gameObject.GetComponent<DisparoJugador>().DisminuciónFireRate(ChangeParameter);
            collision.gameObject.GetComponent<SistemaDeVida>().puntos++;
            Destroy(this.gameObject);
        }
    }

}
