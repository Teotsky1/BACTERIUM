using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //FISICAS
    public float _Speed;
    public Rigidbody2D _PlayerRB;

    private Vector2 _MoveDir;


    [Header("DASH\n")]
    [SerializeField] private float _dashVel = 20f;
    [SerializeField] private float _dashCD = 5f;

    public float _dashingTime = 100f;
    public bool _dasheando;
    public bool _PuedeDashear;

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

        _dashingTime = -_dashingTime * Time.deltaTime;

    }



    private void DashConditiono(bool Dash)
    {
        if (Dash)
        {
            if (_dasheando = false)
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
