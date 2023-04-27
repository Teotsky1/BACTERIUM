using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionEnemigos : MonoBehaviour
{
    [SerializeField]
    private List<EnemyMovement1> enemi;
    private int[] indices = { 0, 1, 2, 3, 4,};

    void Start()
    {
        Shuffle();
        OcultarEnemigo();
        MostrarEnemigo(3);
    }

    public void MostrarEnemigo(int total)
    {
        int indice_enemigo;
        if (total >= 0 && total < enemi.Count)
        {
            for (int i = 0; i < total; i++)
            {
                indice_enemigo = indices[i];
                enemi[indice_enemigo].Mostrar();
            }
        }
    }

    public void OcultarEnemigo()
    {
        for (int i = 0; i < enemi.Count; i++)
        {
            enemi[i].Ocultar();
        }
    }

    public void Shuffle()
    {
        for (int t = 0; t < indices.Length; t++)
        {
            int tmp = indices[t];
            int r = Random.Range(t, indices.Length);
            indices[t] = indices[r];
            indices[r] = tmp;
        }
    }
}
