using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    [Header("DAÑO")]
    [SerializeField] float daño;


    public bool TocaJugador;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject , 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SistemaDeVida>() != null) 
        {

            collision.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño);
            if (collision.CompareTag("Player"))
            Destroy(this.gameObject);
        }


    }

}

