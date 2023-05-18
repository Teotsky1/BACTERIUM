using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] float HpActu;




    public GameObject[] parentDrop;

    public GameObject[] DropPrefab;


    public GameObject[] particlePrefab;
  
    public void RestarVida(float da�o)
    {
        Instantiate(particlePrefab[1], transform.position, Quaternion.identity);
        Instantiate(particlePrefab[0], transform.position, Quaternion.identity);

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
            for (int i = 0; i < DropPrefab.Length; i++)
            {
                Instantiate(DropPrefab[i], parentDrop[i].transform.position, quaternion.identity);
            }
        }
        
    }

    private void Update()
    {
        if (HpActu <= 0 )
        {
            gameObject.SetActive(false);
        }
    }
}
