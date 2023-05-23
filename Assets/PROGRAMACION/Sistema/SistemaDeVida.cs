using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SistemaDeVida : MonoBehaviour
{
    [Header("STATS VIDA")]
    [SerializeField] float Maxhp = 5;
    [SerializeField] float hpActual;

    [Header("INMUNIDAD")]
    public bool Inmunidad = false;
    [SerializeField] float tiempoInmortal = 0.5f;

    public TMP_Text VidaText;
    public GameObject[] vidas;

    public GameObject PlayerDash;

    private bool isGameOver = false;

    private void Start()
    {
        hpActual = Maxhp;
    }

    private void Update()
    {
        if (hpActual > Maxhp) hpActual = Maxhp;

        if (hpActual <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(LoadGameOverScene());
        }

        //INTERFAZ VIDA
        VidaText.text = hpActual.ToString();
    }

    public void QuitarVida(float Daño)
    {
        if (Inmunidad) return;

        hpActual -= Daño;

        StartCoroutine(TiempoInmunidad());

        if (hpActual < 5) vidas[4].SetActive(false);

        if (hpActual < 4) vidas[3].SetActive(false);

        if (hpActual < 3) vidas[2].SetActive(false);

        if (hpActual < 2) vidas[1].SetActive(false);

        if (hpActual < 1) vidas[0].SetActive(false);
    }

    public void Curar(float curacion)
    {
        if (hpActual > Maxhp) return;

        hpActual += curacion;

        if (hpActual >= 2) vidas[1].SetActive(true);

        if (hpActual >= 3) vidas[2].SetActive(true);

        if (hpActual >= 4) vidas[3].SetActive(true);

        if (hpActual >= 5) vidas[4].SetActive(true);
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    IEnumerator TiempoInmunidad()
    {
        Inmunidad = true;
        yield return new WaitForSeconds(tiempoInmortal);
        Inmunidad = false;
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.2f); 
        SceneManager.LoadScene("Muerte"); 
    }
}
