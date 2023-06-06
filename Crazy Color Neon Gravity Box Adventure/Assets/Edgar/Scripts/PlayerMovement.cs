using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _estaAbajo = true;
    private bool _estaSaltando = false;
    private int num=1;
   public float speed = 30;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public Transform Camara;
    private Vector3 _posCamara;
    public Animator CambioCamara;
    public float LimiteX = 5;
    //public Transform RotPlayer;
    public GameObject PanelGameOver;
    public GameObject PanelWin;
    public GameObject PanelGame;
    public GameObject PanelInicio;
    public GameObject PanelLogros;
    public GameObject PanelPuntosArriba;

    private byte _puntaje;

    private void Start()
    {
        Time.timeScale = 1;
        _puntaje = 0;
        
        CambioCamara.SetBool("empezar",false);
        
    }

    private void FixedUpdate ()
    {
        

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        Vector3 posicionActual = transform.position;

       /* // Obtener el nuevo valor para el eje X (limitado)
        float nuevoPosX = Mathf.Clamp(posicionActual.x, -LimiteX, LimiteX);

        // Crear un nuevo Vector3 con el valor limitado en el eje X
        Vector3 nuevaPosicion = new Vector3(nuevoPosX, posicionActual.y, posicionActual.z);

        // Asignar la nueva posición al objeto
        transform.position = nuevaPosicion;*/
        Movimiento();

        if (_puntaje == 5)
        {
            Time.timeScale = 0;
            //PanelWin.SetActive(true);
            PanelGame.SetActive(false);
            PanelLogros.SetActive(true);
            PanelInicio.SetActive(false);
            PanelPuntosArriba.SetActive(false);
        }
	}

    private void Movimiento()
    {
        horizontalInput = num*Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && _estaSaltando == false)
        {
            Debug.Log("Salta");
            rb.AddForce(Vector3.up*20*num,ForceMode.Impulse);
            StartCoroutine(Esperar());
        }
        
	}

    
    IEnumerator Esperar()
    {
        _estaSaltando = true;
        yield return new WaitForSeconds(0.3f);
        _estaSaltando = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cambio"))
        {
            if (_estaAbajo == true)
            {
                Physics.gravity*=-1;
                
                CambioCamara.SetBool("arriba",true);
                CambioCamara.SetBool("abajo",false);
                //Camara.Rotate(180,180,0);
                Camara.localPosition = new Vector3(_posCamara.x,-1.5f,-5);
                num=-1;
                _estaAbajo = false;
            }
            else if(_estaAbajo == false)
            {
                Physics.gravity*=1;
                
                 CambioCamara.SetBool("arriba",false);
                CambioCamara.SetBool("abajo",true);
                //Camara.Rotate(-180,-180,0);
                Camara.localPosition = new Vector3(_posCamara.x,1.5f,-5);
                num=1;
                _estaAbajo = true;
            }
            
        }

        if (other.CompareTag("obstaculo"))
        {
            Time.timeScale = 0;
            PanelGameOver.SetActive(true);
            PanelGame.SetActive(false);
            PanelInicio.SetActive(false);
        }

        if (other.CompareTag("punto"))
        {
            _puntaje++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Final"))
        {
            Time.timeScale = 0;
            PanelGame.SetActive(false);
            PanelInicio.SetActive(false);
            PanelLogros.SetActive(true);
            PanelPuntosArriba.SetActive(false);
        }
    }
}
