using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [Header("Atributos De Disparo")]
    [SerializeField] Transform shootController;
    [SerializeField] GameObject Bala;


    [SerializeField] private float fireRate;
    private float nextFireTime;

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && nextFireTime < Time.time)
        {
            PlayerShoot();
            nextFireTime = Time.time + fireRate;

        }
    }
    

    void PlayerShoot()
    {
        Instantiate(Bala, shootController.position, shootController.rotation);

    }

    public void DisminuciónFireRate(float Disminucion)
    {
        fireRate -= Disminucion;
    }
}
