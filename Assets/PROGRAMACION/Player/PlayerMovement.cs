using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rbp;


    public GameObject[] estamina;


    [Header("Movmimiento")]
    public float playerVelocity = 4f;
    private Vector2 playerDirection;


    [Header("Dash")]
    public float dashForce = 15f;
    public float dashDuration = 0.05f;
    public float dashCD = 4f;

    //public bool estaKeyActive;
    public bool puedeDashear;
    public bool estaDasheando;
    public bool estaEnCD;


    //UNITY METHODS
    private void Awake()
    {
        rbp = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        MOVEINPUTS();
        DASHINPUTS();
    }

    private void FixedUpdate()
    {
        MOVE();
    }


    //CREATED METHODS

    void MOVEINPUTS()
    {
        //MOVE INPUTS
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(moveX, moveY).normalized;
    }

    void DASHINPUTS()
    {
        bool estaKeyActive = Input.GetKey(KeyCode.Space);

        if (estaKeyActive)
        {
            puedeDashear = true;
        }
        else
        {
            puedeDashear = false;
        }

    }

    void MOVE()
    {
        rbp.MovePosition(rbp.position + playerDirection * playerVelocity * Time.deltaTime);

        if (puedeDashear)
        {
            if (!estaDasheando && !estaEnCD)
            {
                DASH();
                
            }
        }
    }

    void DASH()
    {
        rbp.MovePosition(rbp.position + playerDirection * dashForce * playerVelocity * Time.deltaTime);

        StartCoroutine(EnfriamientoDash());
        
    }

    IEnumerator EnfriamientoDash()
    {

        estamina[3].SetActive(false);
        estamina[2].SetActive(false);
        estamina[1].SetActive(false);
        estamina[0].SetActive(false);
        yield return new WaitForSeconds(dashDuration);
        estaEnCD = false;
        estaDasheando = true;
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(ActivarEsta());
        estaDasheando = false;
        estaEnCD = true;
        yield return new WaitForSeconds(dashCD);
        estaEnCD = false;
        estaDasheando = false;
      
    }

    IEnumerator ActivarEsta()
    {
        yield return new WaitForSeconds(1);
        estamina[0].SetActive(true);
        yield return new WaitForSeconds(1);
        estamina[1].SetActive(true);
        yield return new WaitForSeconds(1);
        estamina[2].SetActive(true);
        yield return new WaitForSeconds(1);
        estamina[3].SetActive(true);

    }


}
