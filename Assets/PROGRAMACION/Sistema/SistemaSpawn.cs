using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSpawn : MonoBehaviour
{

    public int CanEnemigos;

    public float tiempoReSpawn;
    



    
    [SerializeField] GameObject[] SpawnParent;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] public float SpawnArea;



    private Transform player;
    private float DistanceFromPlayer;

    public int[] RNumbers;
    public bool primeraVez;

    private void Awake()
    {
        RNumbers = new int[CanEnemigos];
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    


    private void Update()
    {
        Spawn();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2 (SpawnArea , SpawnArea));
    }



    void Spawn()
    {
        DistanceFromPlayer = Vector2.Distance(transform.position , player.position);

        if (DistanceFromPlayer <= SpawnArea && primeraVez == false) 
        {
            
            StartCoroutine(SpawnTimer());
        }




    }
    


    IEnumerator SpawnTimer()
    {
        primeraVez = true;

        for (int i = 0; i < CanEnemigos; i++)
        {
            Vector2 RandomPositionParent = GenerateRandomPosition();

            SpawnParent[i].transform.position = RandomPositionParent;

            Instantiate(enemyPrefab, SpawnParent[i].transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(tiempoReSpawn);
        primeraVez = false;
    }





    Vector2 GenerateRandomPosition()
    {
        float randomX = Random.Range(-SpawnArea / 2, SpawnArea / 2);
        float randomY = Random.Range(-SpawnArea / 2, SpawnArea / 2);


        Vector2 randomPosition = new Vector2(randomX, randomY);

        return randomPosition;
    }
}
