using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Points : MonoBehaviour
{



    public List<GameObject> objetosActivables; // Lista de objetos a activar desde el inspector de Unity

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject objeto in objetosActivables)
            {
                objeto.SetActive(true); // Activa cada objeto de la lista
            }
        }
    }
}


