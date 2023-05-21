using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PausarJuego : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject volver;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarElJuego();
        }
    }

    public void PausarElJuego()
    {
        Time.timeScale = 0f; // Pausar el tiempo del juego
        juegoPausado = true;
        panelPausa.SetActive(true); // Mostrar el panel de pausa
        volver.SetActive(true); // Mostrar el botón adicional en el panel
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        juegoPausado = false;
        panelPausa.SetActive(false); // Ocultar el panel de pausa
        volver.SetActive(false); // Ocultar el botón adicional en el panel
    }
}
