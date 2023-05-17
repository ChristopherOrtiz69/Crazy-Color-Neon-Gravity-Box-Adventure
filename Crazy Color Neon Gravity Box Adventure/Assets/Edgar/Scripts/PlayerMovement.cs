using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _estaAbajo = true;
    private int num=1;
   public float speed = 30;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public Transform Camara;
    private Vector3 _posCamara;
    public float LimiteX = 5;
    //public Transform RotPlayer;

    private void FixedUpdate ()
    {
        

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        Vector3 posicionActual = transform.position;

        // Obtener el nuevo valor para el eje X (limitado)
        float nuevoPosX = Mathf.Clamp(posicionActual.x, -LimiteX, LimiteX);

        // Crear un nuevo Vector3 con el valor limitado en el eje X
        Vector3 nuevaPosicion = new Vector3(nuevoPosX, posicionActual.y, posicionActual.z);

        // Asignar la nueva posición al objeto
        transform.position = nuevaPosicion;
        Movimiento();
	}

    private void Movimiento()
    {
        horizontalInput = num*Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salta");
            rb.AddForce(Vector3.up*20*num,ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            if (_estaAbajo == true)
            {
                Physics.gravity*=-1;
                Camara.Rotate(180,180,0);
                Camara.localPosition = new Vector3(_posCamara.x,-1.5f,-5);
                num=-1;
                _estaAbajo = false;
            }
            else if(_estaAbajo == false)
            {
                Physics.gravity*=1;
                Camara.Rotate(-180,-180,0);
                Camara.localPosition = new Vector3(_posCamara.x,1.5f,-5);
                num=1;
                _estaAbajo = true;
            }
            //Physics.gravity*=-1;
            //RotPlayer.Rotate(0,0,180);
            //Camara.Rotate(180,180,0);
            //Camara.localPosition = new Vector3(_posCamara.x,-1.5f,-5);
        }
    }
}
