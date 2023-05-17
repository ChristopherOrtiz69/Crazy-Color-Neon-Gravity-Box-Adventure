using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public Transform Camara;
    private Vector3 _posCamara;

    private void FixedUpdate ()
    {
        

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salta");
            rb.AddForce(Vector3.up*10,ForceMode.Impulse);
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            Physics.gravity*=-1;
            Camara.Rotate(360,0,0);
            //Camara.position = new Vector3(_posCamara.x,_posCamara.y-1.5f,_posCamara.z);
        }
    }
}
