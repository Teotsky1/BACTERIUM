using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D _PlayerRB;
    [Header("MOVIMIENTO\n")]
    public float _Speed = 4f;
    

    private Vector2 _MoveDir;


    [Header("DASH\n")]
    public float _dashVel = 15f;
    public bool Dasheo;


    [Header("COOLDOWN")]
    public float CoolDownTime = 5f;

    private float CoolDownTimer;
    public bool InCoolDown = false;
   

    private void Awake()
    {
        _PlayerRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        ProcessInputs();
        

    }

    private void FixedUpdate()
    {
        MOVE();

        if (InCoolDown)
        {
            // Se reduce el temporizador del enfriamiento en cada cuadro
            CoolDownTimer -= Time.deltaTime;
            // Si el temporizador ha llegado a cero, el enfriamiento ha terminado
            if (CoolDownTimer <= 0f)
            {
                InCoolDown = false;
                CoolDownTimer = 0f;

            }
        }
    }
    private void ProcessInputs()
    {
        //NORMAL MOVEMENT
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        _MoveDir = new Vector2(MoveX, MoveY).normalized;
        
        
        
        //DASHEO
        bool Dasheo = Input.GetKey(KeyCode.Space);

       
    }

    private void MOVE()
    {
        if (!InCoolDown && Dasheo)
        {
            _PlayerRB.MovePosition(_PlayerRB.position + _MoveDir * Time.deltaTime * _dashVel);
            StartCooldown();
        }
        else
        {
            _PlayerRB.MovePosition(_PlayerRB.position + _MoveDir * _Speed * Time.deltaTime);
        }
        
    }


    private void StartCooldown()
    {
        InCoolDown = true;
        CoolDownTimer = CoolDownTime;
    }
}
