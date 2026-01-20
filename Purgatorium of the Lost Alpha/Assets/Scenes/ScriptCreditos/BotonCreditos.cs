using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonCreditos : MonoBehaviour
{
    [Header("Botón que cambiará la escena")]
    public Button boton;

    [Header("Nombre de la escena a cargar")]
    public string nombreEscena;

    private void Start()
    {
        if (boton != null)
        {
            boton.onClick.AddListener(CambiarEscena);
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún botón en el Inspector.");
        }
    }

    public void CambiarEscena()
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el nombre de la escena.");
        }
    }
}

