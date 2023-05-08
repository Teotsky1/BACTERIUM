using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D RedBulletrb;

    [Header("DAÑO")]
    [SerializeField] float daño = 1;

    


    public bool TocaJugador;

    private void Start()
    {
        RedBulletrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        RedBulletrb.velocity = new Vector2(moveDir.x , moveDir.y );
        Destroy(this.gameObject, 1.5f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SistemaDeVida>() != null)
        {
            collision.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño);
            TocaJugador = true;
            new WaitForSeconds(3);
            collision.gameObject.GetComponent<SistemaDeVida>().QuitarVida(daño);

            if (collision.CompareTag("Player"))
                Destroy(this.gameObject);
        }


    }


    
}
