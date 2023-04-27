using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private float bulletVel;
    //[SerializeField] private float daño;


    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * bulletVel * Time.deltaTime);
        Destroy(this.gameObject , 1.5f);
    }
}
