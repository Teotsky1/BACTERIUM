using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
  public void OnpressJugar()
    {
        
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
    }

    public void Onpressinstrucciones()
    {
        
        SceneManager.LoadScene("instrucciones", LoadSceneMode.Single);
    }

    public void OnpressVolverMenu()
    {
        
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

     public void OnpressSalir()
    {
        
    }

     public void OnpressPausa()
    {
        
        SceneManager.LoadScene("Pausa", LoadSceneMode.Single);
    }

}