using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool turnLeft, turnRight;
    public float Velocidad = 30f;
    public CharacterController MyCharacterController;
    public Rigidbody MyRigibody;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        //MyCharacterController.Move(transform.forward * Velocidad * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salta");
            MyRigibody.AddForce(Vector3.up*10,ForceMode.Impulse);
        }
        
    }
}