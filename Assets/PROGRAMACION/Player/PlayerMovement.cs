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
    public float _dashCD;
    public float _dashingTime = 0.3f;

    public bool _dasheando;
    public bool _PuedeDashear;

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
    }
    private void ProcessInputs()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        _MoveDir = new Vector2(MoveX, MoveY).normalized;

        bool Dash = Input.GetButtonDown("Dash");
        
        if (Dash)
        {
            _dashingTime = -_dashingTime * Time.deltaTime;
            _dashCD = 5f;
        }
        


    }



    private void DashConditiono(bool Dash)
    {
        if (Dash)
        {
            if (_dasheando == false)
            {
                if (_dashCD <= 0)
                {
                    _PuedeDashear = true;
                }
                
            }
        }
    }

    private void MOVE()
    {
        _PlayerRB.MovePosition(_PlayerRB.position + _MoveDir * _Speed * Time.deltaTime);
    }

    

}
