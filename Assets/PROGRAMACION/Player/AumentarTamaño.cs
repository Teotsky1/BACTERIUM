using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AumentarTamaño : MonoBehaviour
{
    [SerializeField] public float valorAumento;
    [SerializeField] public AudioClip Recoleccionsonido;
    private  Vector3 newSize;
    private AudioSource Audio;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<DropAumento>()  != null)
        {
            valorAumento = collision.gameObject.GetComponent<DropAumento>().Cambiazzo();
            ModificarTamaño(valorAumento);
            Destroy(collision.gameObject);
        }

        Audio = GetComponent<AudioSource>();
        Audio.PlayOneShot(Recoleccionsonido,1.0f);

    }

    public void ModificarTamaño(float cambio)
    {
        newSize = new Vector3 (cambio, cambio, cambio);

        transform.localScale += newSize; 
    }
}
