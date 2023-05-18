using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] float Da�o;
    [SerializeField] float BulletVel;


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * BulletVel * Time.deltaTime);
        Destroy(this.gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<VidaEnemigos>() != null)
        {
            other.gameObject.GetComponent<VidaEnemigos>().RestarVida(Da�o);

            if (other.CompareTag("Enemys"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
