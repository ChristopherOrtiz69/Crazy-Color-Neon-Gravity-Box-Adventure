using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cambio_Escena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que se desea cambiar

    public void CambiarAEscena()
    {
        SceneManager.LoadScene(nombreEscena); // Carga la escena con el nombre especificado
    }
}
