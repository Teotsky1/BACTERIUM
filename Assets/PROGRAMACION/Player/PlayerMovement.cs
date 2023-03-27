using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    //Fisicas
    private Rigidbody2D playerRB;
    [SerializeField] private float speed = 5f;

    //Vector 2D
    private Vector2 moveInput;


    
    //DASH
    [SerializeField] private float dashCoolDown;
    [SerializeField] private float dashSpeed = 15f;



    



    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;


    }


    private void FixedUpdate()
    {
        //Fisicas
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);

    }

    void DASH(bool isDashing) 
    {
    
    
    
    }

}
