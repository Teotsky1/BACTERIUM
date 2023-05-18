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
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
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
      
        if (player != null)
        {
            enemyDistanceFromPlayer = Vector2.Distance(transform.position, player.position);

            if (enemyDistanceFromPlayer <= lineOfSite)
            {
                transform.position = Vector2.MoveTowards(this.transform.position , player.position, enemyVelocity * Time.deltaTime);
            }
        }
    }

 

    public void CongelarEnemigo(float tiempo)
    {
        StartCoroutine(Congelamiento(tiempo));
    }

    public IEnumerator Congelamiento(float tiempo)
    {
        enemyVelocity = 0;
        yield return new WaitForSeconds(tiempo);
        enemyVelocity = 2;
    }
}
