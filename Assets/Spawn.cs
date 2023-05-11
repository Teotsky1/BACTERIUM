using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ParentEnemy;
    public GameObject TargetEnemy;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 50f);
    }

    private void Start()
    {
        Instantiate(TargetEnemy, ParentEnemy.transform.position, Quaternion.identity);
    }
}
