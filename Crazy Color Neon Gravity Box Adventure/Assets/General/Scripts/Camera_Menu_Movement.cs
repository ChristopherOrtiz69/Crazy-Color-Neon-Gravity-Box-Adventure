using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Menu_Movement : MonoBehaviour

{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento ajustable desde el inspector de Unity
    private Vector3 posicionInicial; // Posición inicial de la cámara

    void Start()
    {
        // Guardar la posición inicial de la cámara al inicio del juego
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Obtener la dirección hacia adelante de la cámara
        Vector3 direccionAdelante = transform.forward;

        // Calcular el desplazamiento multiplicando la dirección por la velocidad y el tiempo
        float desplazamiento = velocidadMovimiento * Time.deltaTime;

        // Actualizar la posición de la cámara sumando el desplazamiento a la posición actual
        transform.position += direccionAdelante * desplazamiento;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la cámara ha entrado en contacto con otro objeto
        if (other.CompareTag("ObjetoReinicio"))
        {
            // Reiniciar la posición de la cámara a la posición inicial
            transform.position = posicionInicial;
        }
    }
}
