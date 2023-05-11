using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] float HpActu;
    //[SerializeField] float daño = 1;

    private bool puedeDropear;


    public GameObject[] parentDrop;

    public GameObject[] DropPrefab;

    public void RestarVida(float daño)
    {
        HpActu -= daño;

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
