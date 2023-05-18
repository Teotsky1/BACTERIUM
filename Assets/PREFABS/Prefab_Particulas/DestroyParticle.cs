using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(DestroyP());
    }

    IEnumerator DestroyP()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
