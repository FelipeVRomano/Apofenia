using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControle : MonoBehaviour
{

    private float velMove = 2f;
    private Rigidbody2D rb;
    private bool moveE;
    [SerializeField]
    private Transform limite;

    public LayerMask layer;
    private Animator anim;

    [SerializeField]
    private bool visaoV;
    [SerializeField]
    private float raio;
    [SerializeField]
    private LayerMask layerV;
    [SerializeField]
    private SpriteRenderer srender;
    // Start is called before the first frame update
    private Rigidbody2D RB;
    private Transform Tr;

    public bool TiroD;
    public bool TiroE;
    public bool VendoJogador = false;

    public bool face = false;

    private bool atira;
    //
    //
   public SoldadoArma Arma;
   public SoldadoArma Arma2;
   


    [SerializeField]
    private float cudaun;
    [SerializeField]
    private float cudaun2;

    public static bool veriFlip;
    [SerializeField]
    private float cooldownTiroBot;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(12, 12);
        rb = GetComponent<Rigidbody2D>();
        moveE = true;
        TiroE = true;
        anim = GetComponent<Animator>();

        srender = GetComponent<SpriteRenderer>();

        RB = gameObject.GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();

        atira = false;
        cudaun = 0;
        cudaun2 = 0;
        veriFlip = srender.flipX;
    }

    // Update is called once per frame
    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);
        if(srender.flipX)
        {
            veriFlip = true;
        }
        else if (!srender.flipX)
        {
            veriFlip = false;
        }
        if (visaoV)
        {
            var relativeP = transform.InverseTransformPoint(Physics2D.OverlapCircle(transform.position, raio, layerV).gameObject.transform.position);
            //print(relativeP.x);

            if (relativeP.x >0.0f && atira)
            {
                VendoJogador = true;
                TiroE = true;
                TiroD = false;
                //print("Esquerda");
                srender.flipX = false;
                cudaun2 = 0;
                cudaun += Time.deltaTime;
                anim.SetBool("atira", true);
                if (cudaun > cooldownTiroBot)
                {
                    TiroSoldado.frente = false;
                    SoldadoArma Tiro = Arma;
                    Tiro.Attack();
                    cudaun = 0;
                }
                
            }
            else if (relativeP.x < 0.0f && atira)
            {
                VendoJogador = true;
                TiroE = false;
                TiroD = true;
                //print("Direita");
                srender.flipX = true;
                cudaun = 0;
                cudaun2 += Time.deltaTime;
                anim.SetBool("atira", true);
                if (cudaun2 > cooldownTiroBot)
                {
                    TiroSoldado.frente = true;
                    SoldadoArma Tiro = Arma2;
                    Tiro.Attack();
                    cudaun2 = 0;
                }
            }
            else if (relativeP.x < 0.0f && !atira)
            {
                VendoJogador = true;
                TiroE = false;
                TiroD = true;
                srender.flipX = true;
                anim.SetBool("atira", true);
                
            }
            else if (relativeP.x > 0.0f && !atira)
            {
                VendoJogador = true;
                TiroE = true;
                TiroD = false;
                srender.flipX = false;
                anim.SetBool("atira", true);
            }

            else
            {
                anim.SetBool("atira", false);
                VendoJogador = false; 
                TiroE = false;
                TiroD = false;
                srender.flipX = false;
                cudaun = 0;
                cudaun2 = 0;
            }
       
        }

       if(PauseMenu.jogopausado == false && Dialogo.estaFalando == false && NewBehaviourScript.estaFalando3 == false)
        {
            atira = true;
        }
        else if (PauseMenu.jogopausado || Dialogo.estaFalando || NewBehaviourScript.estaFalando3)
        {
            atira = false;
        }

    }

    /*void VerificaCol()
    {
       if(!Physics2D.Raycast(limite.position,Vector2.down,0.1f,layer))
       {
           Flip();
       }
    }
    */

    void Flip()
    {
       
        /*moveE = !moveE;
        Vector3 temp = transform.localScale;
        if(moveE)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else
        {
            temp.x = -Mathf.Abs(temp.x);
        }

        transform.localScale = temp;
        
        face = !face;

        Vector3 scala = transform.localScale;
        scala.x *= -1;
        transform.localScale = scala;
        */

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bala"))
        {
            Destroy(gameObject, 0.6f);
            Destroy(col.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
