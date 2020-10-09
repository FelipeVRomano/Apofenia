using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquinaSpawn : MonoBehaviour
{
    [SerializeField]
    private bool visaoV;
    [SerializeField]
    private float raio;
    [SerializeField]
    private LayerMask layerV;
    [SerializeField]
    private SpriteRenderer srender;

    public Animator aniM;
    //public GameObject portao1;
    //public GameObject portao2;
    public bool Ativado;
    //public GameObject botao;

    [SerializeField]
    private GameObject Somativa;



    // Start is called before the first frame update
    void Start()
    {
        Ativado = false;
        srender = GetComponent<SpriteRenderer>();
       // portao1.SetActive(true);
        //portao2.SetActive(true);
        //botao.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);


        if (visaoV && Ativado) 
            
         {

            aniM.SetBool("liga", true);
            Somativa.SetActive(true);
           
         }
        
        else
        {
           // botao.SetActive(false);

            aniM.SetBool("liga", false);
            Somativa.SetActive(false);
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Ativado = true;
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Ativado = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
   
   
}
