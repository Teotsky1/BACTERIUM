using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public float lineOfSite;
    public float enemyVelocity;
    private Transform player;
    private float enemyDistanceFromPlayer;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
        
    
    
    private void FixedUpdate()
    {
        ENEMYMOVE();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
     
    }

    void ENEMYMOVE()
    {
        enemyDistanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (enemyDistanceFromPlayer <= lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position , player.position, enemyVelocity * Time.deltaTime);
            
        }
    }





}
