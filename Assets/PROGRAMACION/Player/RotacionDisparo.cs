using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionDisparo : MonoBehaviour
{
    [Header("Rotacion De Mouse")]
    private Vector3 objetivo;
    [SerializeField] private Camera cam;
    private float anguloRadianes;
    private float anguloGrados;

    void Update()
    {
        objetivo = cam.ScreenToWorldPoint(Input.mousePosition);
        anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
    }
}
