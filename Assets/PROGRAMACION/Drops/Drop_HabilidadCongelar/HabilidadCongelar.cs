using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HabilidadCongelar : MonoBehaviour
{
    bool puedeUtlizarFreeze;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puedeUtlizarFreeze = true;
            collision.gameObject.GetComponent<TabKey>().ActivarCongelamiento(puedeUtlizarFreeze);

            Destroy(this.gameObject);
        }
    }
}
