using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAumento : MonoBehaviour
{
    [Header("Aumentar Tama�o")]
    [SerializeField] public float Aumentar;

    public float Cambiazzo()
    {
        return Aumentar;
    }

    public void Update()
    {
        Destroy(gameObject,6f);
    }

}
