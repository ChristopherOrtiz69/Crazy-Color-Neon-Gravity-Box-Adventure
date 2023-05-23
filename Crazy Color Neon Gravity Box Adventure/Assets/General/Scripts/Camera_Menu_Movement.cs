using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Menu_Movement : MonoBehaviour

{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento ajustable desde el inspector de Unity
    private Vector3 posicionInicial; // Posici�n inicial de la c�mara

    void Start()
    {
        // Guardar la posici�n inicial de la c�mara al inicio del juego
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Obtener la direcci�n hacia adelante de la c�mara
        Vector3 direccionAdelante = transform.forward;

        // Calcular el desplazamiento multiplicando la direcci�n por la velocidad y el tiempo
        float desplazamiento = velocidadMovimiento * Time.deltaTime;

        // Actualizar la posici�n de la c�mara sumando el desplazamiento a la posici�n actual
        transform.position += direccionAdelante * desplazamiento;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la c�mara ha entrado en contacto con otro objeto
        if (other.CompareTag("ObjetoReinicio"))
        {
            // Reiniciar la posici�n de la c�mara a la posici�n inicial
            transform.position = posicionInicial;
        }
    }
}
