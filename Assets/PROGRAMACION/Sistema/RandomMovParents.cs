using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovParents : MonoBehaviour
{
    public float Range ;

    private void Start()
    {
        transform.position = Vector2.zero;
        
        
        
        Vector2 randomPosition = randomposition();
        
        
        randomposition();
    }


    Vector2 randomposition()
    {
        GameObject Objeto = GameObject.Find("Spawn");

        if (Objeto != null)
        {
            Range = (Objeto.GetComponent<SistemaSpawn>().SpawnArea)/2;
        }
        

        float xRandom = Random.Range(-1 - (-1 * Range), Range + 1);
        float yRandom = Random.Range(-1 - (-1 * Range), Range + 1);


        
        return transform.position = Vector2.MoveTowards(transform.position, new Vector2(xRandom, yRandom), 5000f);

    }
}
