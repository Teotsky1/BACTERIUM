using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private float bulletVel;
    [SerializeField] private float Daño;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * bulletVel * Time.deltaTime);
        Destroy(this.gameObject , 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<VidaEnemigos>() != null) 
        {
            collision.gameObject.GetComponent<VidaEnemigos>().RestarVida(Daño);
            Destroy(this.gameObject);
        }
        Debug.Log("toca al enemigo");
    }
}
