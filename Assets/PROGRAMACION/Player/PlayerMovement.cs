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
    public float _dashCD = 1f;
    public float _dashingTime = 0.2f;

    public bool _dasheando;
    public bool _PuedeDashear;
    private float _dasheo;

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
        //NORMAL MOVEMENT
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        _MoveDir = new Vector2(MoveX, MoveY).normalized;

        bool Dasheo = Input.GetKey("Dash");

        /*if (Dasheo)
        {
            _PuedeDashear = true;
            StartCoroutine(DashRoutine());
        }*/
    }

    /*private IEnumerator DashRoutine()
    {
        if (_PuedeDashear)
        {
            _dasheando = true;
            _PuedeDashear = false;
            yield return new WaitForSeconds(_dashingTime);
            _dasheando = false;
            yield return new WaitForSeconds(_dashCD);
            _PuedeDashear = true;

        }
    }*/


    private void MOVE()
    {
        
        
            _PlayerRB.MovePosition(_PlayerRB.position + _MoveDir * _Speed * Time.deltaTime * _dashVel);
        
        
        
            _PlayerRB.MovePosition(_PlayerRB.position + _MoveDir * _Speed * Time.deltaTime);
        
           
    }

    

}
