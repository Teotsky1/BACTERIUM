using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;

    public float proximityRange;

    public float fireRate = 3f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        ENEMYMOVE();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, proximityRange);
    }

    void ENEMYMOVE()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;

        }

        if (distanceFromPlayer <= proximityRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, -1.3f * speed * Time.deltaTime);
        }

    }


}
