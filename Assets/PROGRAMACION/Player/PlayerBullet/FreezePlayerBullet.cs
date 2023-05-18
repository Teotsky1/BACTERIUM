using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] float Daño;
    [SerializeField] float BulletVel;
    private float tiempocongelado;


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * BulletVel * Time.deltaTime);
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<VidaEnemigos>() != null)
        {
            other.gameObject.GetComponent<VidaEnemigos>().RestarVida(Daño);






            if (other.gameObject.GetComponent<EnemyMovement1>() != null)
            {
                other.gameObject.GetComponent<EnemyMovement1>().CongelarEnemigo(tiempocongelado);
            }
                









            if (other.CompareTag("Enemys"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
