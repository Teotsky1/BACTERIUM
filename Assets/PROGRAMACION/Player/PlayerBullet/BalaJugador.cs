using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    [Header("STATS")]
    [SerializeField] float BulletVel;
    [SerializeField] float da�o;


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * BulletVel * Time.deltaTime);
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<VidaEnemigos>() != null)
        {
            collision.gameObject.GetComponent<VidaEnemigos>().RestarVida(da�o);
                
        }
        Destroy(this.gameObject);
    }
}
