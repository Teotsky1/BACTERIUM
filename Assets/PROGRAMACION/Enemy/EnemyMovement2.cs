using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public float lineOfSite;
    public float enemyVelocity;
    private Transform newPlayer;
    private float enemyDistanceFromPlayer;
    public float shootingRange;
    public float fireRatio;
    public GameObject bala;
    public GameObject bulletParent;

    private void Start()
    {
        newPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        ENEMYMOVE();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos .color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    void ENEMYMOVE()
    {
        enemyDistanceFromPlayer = Vector2.Distance(transform.position, newPlayer.position);

        if (enemyDistanceFromPlayer < lineOfSite )
        {
            transform.position = Vector2.MoveTowards(this.transform.position, newPlayer.position, enemyVelocity * Time.deltaTime);
        }
       
    }
}
