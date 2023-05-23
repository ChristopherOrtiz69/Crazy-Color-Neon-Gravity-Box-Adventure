using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour


{
    public float rotationSpeed = 10f; // Velocidad de rotación

    // Método que se llama en cada frame
    void Update()
    {
        // Rotar el objeto alrededor de un punto en el espacio
        transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}



