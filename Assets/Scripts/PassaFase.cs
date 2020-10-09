using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaFase : MonoBehaviour
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
    public GameObject luzVerm;
    public GameObject luzVerde;
    public bool Ativado;
    [SerializeField]
    private GameObject Somativa;
    //public GameObject botao;


    // Start is called before the first frame update
    void Start()
    {
        Ativado = false;
        srender = GetComponent<SpriteRenderer>();
        


    }

    // Update is called once per frame
    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);


        if (visaoV && Ativado)

        {
            //botao.SetActive(true);


            aniM.SetBool("abrindo", true);
            aniM.SetBool("fechando", false);
            Somativa.SetActive(true);
            //  portao1.SetActive(false);
            // portao2.SetActive(false);

        }

        else
        {
            // botao.SetActive(false);

            aniM.SetBool("abrindo", false);
            aniM.SetBool("fechando", true);
            Somativa.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                luzVerm.SetActive(false);
                luzVerde.SetActive(true);
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
                luzVerm.SetActive(false);
                luzVerde.SetActive(true);
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
