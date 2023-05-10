using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] float Daño;
    [SerializeField] float BulletVel;


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * BulletVel * Time.deltaTime);
        Destroy(this.gameObject,1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player") != true) 
        {
            Debug.Log("Toca al Enemy");
        
        }
    }
}
