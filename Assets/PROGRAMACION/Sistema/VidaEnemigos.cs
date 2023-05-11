using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] float HpActu;
    //[SerializeField] float da�o = 1;

    private bool puedeDropear;


    public GameObject[] parentDrop;

    public GameObject[] DropPrefab;

    public void RestarVida(float da�o)
    {
        HpActu -= da�o;

        if(HpActu <= 0)
        {
            Dropeo();
        }
        
    }
    public void Dropeo()
    {
        if (HpActu <= 0 )
        {
            Instantiate(DropPrefab[0], parentDrop[0].transform.position, Quaternion.identity);
            Instantiate(DropPrefab[1], parentDrop[1].transform.position, Quaternion.identity);
            Instantiate(DropPrefab[2], parentDrop[2].transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
}
