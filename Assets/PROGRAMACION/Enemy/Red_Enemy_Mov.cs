using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Red_Enemy_Mov : MonoBehaviour
{
    [Header ("MOVEMENT")]
    [SerializeField] float REspeed;



    [Header("DISTANCIA GYSMOS")]
    [SerializeField] float ChasingArea;
    [SerializeField] float ShhotingRange;


    private Transform Tplayer;


    private float DistanceF_Player;

    [Header("DISPARO")]
    public GameObject[] BulletPrefab;
    public GameObject[] BulletParent2;


    [SerializeField] public float FireRate = 1.6f;
    private float NextFireTime;

    public GameObject CambioSprite;
    [SerializeField] public Sprite normal;
    [SerializeField] public Sprite FrozenSprite;





    void Start()
    {
        Tplayer = GameObject.FindGameObjectWithTag("Player").transform;
    }



    private void FixedUpdate()
    {
        Red_Movement_M();

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChasingArea);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, ShhotingRange);
    }

    void Red_Movement_M()
    {
        DistanceF_Player = Vector2.Distance(Tplayer.position, transform.position);


        if (DistanceF_Player <= ChasingArea)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Tplayer.position, REspeed * Time.deltaTime);
            
            if (DistanceF_Player <= ShhotingRange && NextFireTime < Time.time)
            {
                Instantiate(BulletPrefab[0], BulletParent2[0].transform.position, Quaternion.identity);
                Instantiate(BulletPrefab[1], BulletParent2[1].transform.position, Quaternion.identity);
                Instantiate(BulletPrefab[2], BulletParent2[2].transform.position, Quaternion.identity);

                NextFireTime = Time.time + FireRate;
            }
        }
    }


    public void CongelarEnemigo(float tiempo)
    {
        StartCoroutine(Congelamiento(tiempo));
    }

    public IEnumerator Congelamiento(float tiempo)
    {
        REspeed = 0;

        CambioSprite.GetComponent<SpriteRenderer>().sprite = FrozenSprite;

        CambioSprite.GetComponent <Animator>().enabled = false;

        CambioSprite.GetComponent<Transform>().localScale = Vector3.one;

        yield return new WaitForSeconds(tiempo);


        CambioSprite.GetComponent<SpriteRenderer>().sprite = normal;

        CambioSprite.GetComponent<Transform>().localScale = new Vector3 (2.38f , 2.38f , 2.38f);

        CambioSprite.GetComponent<Animator>().enabled = true;

        REspeed = 2;
    }
}
