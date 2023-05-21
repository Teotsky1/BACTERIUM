using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [Header("Atributos De Disparo")]


    [SerializeField] Transform shootController;
    [SerializeField] GameObject[] Balas;

    [SerializeField] public AudioClip sonidodisparo;
    [SerializeField] private float fireRate;
    private float nextFireTime;
    private AudioSource Audio;



    
    public int CambioDebala;

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
        
        Instantiate(Balas[CambioDebala], shootController.position, shootController.rotation);

        Audio = GetComponent<AudioSource>();
        Audio.PlayOneShot(sonidodisparo);
    }

    
    public void DisminuciónFireRate(float Disminucion)
    {
        fireRate -= Disminucion;
    }
}
