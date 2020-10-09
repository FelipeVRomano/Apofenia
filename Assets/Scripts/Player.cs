

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float puloMenorY = 6f; public float puloMaiorY = 2f;
    public Rigidbody2D Perso;
    //public static bool face = true;
    //public static bool face = true;
    //dashVel
    public float speed = 15f;
    public float speed2 = 30f;
    //velpuloouandar
    public  static float vel = 5.5f;
    public static float move;
    [SerializeField]
    private bool morreu;
    public float force;
    public GameObject mir;

    public static  int HP = 3;
    public bool nochao;
    public bool EsteriaD;
    public bool EsteriaE;
    public Transform check;
    public LayerMask chaoSim;
    public float jumpForce = 10.0f;
    public float raio = 0.2f;
    public bool AtivarPC;
    //
    public Vector2 direcaoH;
    private WaitForSeconds tempo = new WaitForSeconds(1);
    //animacao
    public Animator anim;

    //controlaAnimaçãoTiro
    [SerializeField]
    private float travaEnter;

    public GameObject LastCheckpoint;
    //dash
    public float timer = 0f;
    public bool dashAtivo = true;
    public bool dashUsando = false;

    public float RecargaDash = 1;
    public bool DashCharge =false;


    private SpriteRenderer srender;
    public static bool adivinhaFace;
    [SerializeField]
    private float flep;
    public PlayerArma Arma;
    public PlayerArma Arma2;

    //sons
    public AudioSource passo;
    public AudioSource dash;
    public AudioSource dead;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    // Use this for initialization

    //timerDoChoqueElaser
    public float contaChoque = 2;
    [SerializeField]
    private float retiraVel;
    [SerializeField]
    private float aumentaVel;
    public bool Imortal = false;

    public Animator morte;
    public float waittime;
    private bool delay;
    public float addVel;
    public bool Acontece;
    public GameObject text;
    void Start ()
    {

        morreu = false;
        Perso = GetComponent<Rigidbody2D>();
        //voltar
        Arma = GameObject.FindGameObjectWithTag("ArmaPlayer").GetComponent<PlayerArma>();
        anim = GetComponent<Animator>();
        direcaoH = Vector2.right;
        aumentaVel = 0;
        retiraVel = 0;
       // vira = 0;
        travaEnter = 1;
        
        srender = GetComponent<SpriteRenderer>();
        waittime = 0;
        delay = false;
        Acontece = false;
        HP = PlayerPrefs.GetInt("HP");
        speed = 2500;
        speed2 = 2500;
    }
  
  

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {  
                                     Imortal = !Imortal;                                  
        }

       
        if (srender.flipX)
        {
            adivinhaFace = true;
        }
        else if(!srender.flipX)
        {
            adivinhaFace = false;
        }
      
        if ( Input.GetKeyDown(KeyCode.C) && move == 0 && nochao )
        {
            anim.SetTrigger("Tiro");
        }

        if(Input.GetKeyDown(KeyCode.C) && move != 0 && nochao)
        {
            anim.SetTrigger("TiroAndando");
        }

        if(Input.GetKeyDown(KeyCode.C) && move !=0 && !nochao)
        {
            anim.SetTrigger("TiroPulando");
        }

        if (Input.GetKeyDown(KeyCode.C) && move == 0 && !nochao)
        {
            anim.SetTrigger("TiroPulando");
        }

        //pulo

        nochao = Physics2D.OverlapCircle(check.position, raio, chaoSim);
        if (PauseMenu.jogopausado == false && Dialogo.estaFalando == false && NewBehaviourScript.estaFalando3 == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && nochao)
            {

                // Perso.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                jumpTimeCounter = jumpTime;
                Perso.velocity = Vector2.up * jumpForce;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (jumpTimeCounter > 0 && isJumping == true)
                {
                    Perso.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;
            }
        }
         //dash
        if (dashAtivo == true && PauseMenu.jogopausado == false && Dialogo.estaFalando == false && NewBehaviourScript.estaFalando3 == false)
       {
            if (Input.GetKey(KeyCode.X) && srender.flipX == false && move !=0)
            {
                dashUsando = true;
                timer += Time.deltaTime;
                //transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
                Perso.AddForce(transform.right * speed * Time.deltaTime);
                anim.SetBool("dash", true);
                //tocaDash();
                dash.Play();
            }
            else if (Input.GetKey(KeyCode.X) && srender.flipX && move !=0)
            {
                dashUsando = true;
                timer += Time.deltaTime;
                //transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
                Perso.AddForce(-transform.right * speed);
                anim.SetBool("dash", true);
                // tocaDash();
                dash.Play();
            }
            else if (Input.GetKey(KeyCode.X) && srender.flipX == false && move == 0)
            {
                dashUsando = true;
                timer += Time.deltaTime;
                //transform.position += new Vector3(speed2 * Time.deltaTime, 0.0f, 0.0f);
                Perso.AddForce(transform.right * speed2);
                anim.SetBool("dash", true);
                //tocaDash();
                dash.Play();
                //print("Ei");
            }
            else if (Input.GetKey(KeyCode.X) && srender.flipX == true && move == 0)
            {
                dashUsando = true;
                timer += Time.deltaTime;
                //transform.position += new Vector3(-speed2 * Time.deltaTime, 0.0f, 0.0f);
                Perso.AddForce(-transform.right * speed2);
                anim.SetBool("dash", true);
                //tocaDash();
                dash.Play();
            }
            else
            {
                dashUsando = false;
                
            }
        }
        if(dashUsando ==false)
        {
            anim.SetBool("dash", false);
        }
        //timer do dash
        if (timer>0.1)
        {
            dashUsando = false;  
            dashAtivo = false;
            DashCharge = true;
            timer = 0;
        }
        if (timer <= 0 && RecargaDash <= 0)
            {
            DashCharge = false;
            dashAtivo = true;
            RecargaDash = 1;
        }
        if(DashCharge)
        {
            RecargaDash -= Time.deltaTime;
        }

        

        
        
        if ( dashUsando == false && PauseMenu.jogopausado == false && Dialogo.estaFalando == false && NewBehaviourScript.estaFalando3 == false)
        {
            move = Input.GetAxis("Horizontal");
            anim.SetFloat("X", Mathf.Abs(move));
         }
        else
        {
            move = 0;
            anim.SetFloat("X", Mathf.Abs(0));
            
        }
        if(move !=0 && nochao ==true && (PauseMenu.jogopausado == false))
        {
            passo.UnPause();
        }
        else
        {
           passo.Pause();
        }
        
        if(transform.localScale.x>0)
        {
            direcaoH = Vector2.zero;
            direcaoH += Vector2.right;

        }

        else
        {
            direcaoH = Vector2.zero;
            direcaoH += Vector2.left;
        }
        anim.SetFloat("Y", Perso.velocity.y);
        anim.SetBool("chao", nochao);
        if(delay)
        {
            waittime += Time.deltaTime;
            Dialogo.estaFalando = true;
            //Time.timeScale = 0;

        }
        else if(!delay)
        {
            Dialogo.estaFalando = false;
            //Time.timeScale = 1;
        }
        if (waittime > 1)
        {
            HP = 3;
            transform.position = LastCheckpoint.transform.position;
            waittime = 0;
            text.SetActive(false);
            morte.SetBool("Morrer", false);
            dead.Stop();
            delay = false;
        }
        if(move !=0 && !nochao)
        {
            Acontece = true;
        }
        else
        {
            Acontece = false;
        }
        if (Acontece)
        {
            vel += addVel;
        }
        else if(!Acontece)
        {
            vel = 5.5f;
        }
    }

    public void DanoPlayer(int damageCount)
    {
        if (Imortal == false)
        {
            HP -= damageCount;
        }
        if (HP <= 0)
        {
            morte.SetBool("Morrer", true);
            text.SetActive(true);
            dead.Play();
            delay = true;
            
        }

    }
    public void tocaDash()
    {
        dash.Play();
    }
    public void CuraPlayer(int curaCount)
    {
        HP += curaCount;

        if (HP >= 3)
        {
            HP = 3;

        }

    }
    void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "PC")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                maquinaSpawn MaquinaPC = gameObject.GetComponent<maquinaSpawn>();
                MaquinaPC.Ativado = true;

            }
        }
    }

    void FixedUpdate()
    {

       
        
        if (Perso.velocity.y < 0)
        {
            Perso.gravityScale = puloMenorY;
        }

        else if (Perso.velocity.y > 0 )//&& !Input.GetKeyDown(KeyCode.Space))
        {
            Perso.gravityScale = puloMaiorY;

        }
        else
        {
            Perso.gravityScale = 0.6f;
        }

        
           Perso.velocity = new Vector2(move * vel, Perso.velocity.y);
        

        if (move > 0)
        {
            srender.flipX = false;
        }
        else if (move < 0)
        {
            srender.flipX = true;
        }


        if (Input.GetKeyDown(KeyCode.C) && !srender.flipX)
        {


            PlayerArma Tiro = Arma;

            Tiro.Attack();
        }

        else if (Input.GetKeyDown(KeyCode.C) && srender.flipX)
        {
            PlayerArma Tiro = Arma2;
            Tiro.Attack();
        }

    }
       
  
    
    //flipa o sprite
    /*public void flip()
    {
        face = !face;

        Vector3 scala = transform.localScale;
        scala.x *= -1;
        transform.localScale = scala;
        //vira++;
        
    }
    */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Inimigo"))
        {
            KnockBack(-1f * direcaoH.x);
            DanoPlayer(1);
        }
        if (collision.gameObject.CompareTag("Plataforma"))
            this.transform.parent = collision.transform;

        if (collision.gameObject.CompareTag("Choque"))
        {
            MudaCor();
            DanoPlayer(1);
        }
        if (collision.gameObject.tag == "Bala")
        {
            
            KnockBack(-1f * direcaoH.x);
            MudaCor();
            DanoPlayer(1);
        }

        if (collision.gameObject.CompareTag("laser"))
        {
            KnockBack(-1f * direcaoH.y);
            DanoPlayer(3);
        }

        if(collision.gameObject.CompareTag("esteiraNeg"))
        {
           
        }
        if (collision.gameObject.CompareTag("esteiraPos"))
        {
           
        }
        if (collision.gameObject.CompareTag("parede") && dashUsando)
        {
            //dashAtivo = false;
            // speed = 0;
            // speed2 = 0;

        }


    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("laser") )
        {
            contaChoque+= Time.deltaTime;
            if (contaChoque > 1)
            {
                KnockBack(-1f * direcaoH.y);
                DanoPlayer(1);
                contaChoque = 0;
            }
        }
        if (collision.gameObject.CompareTag("Choque") )
        {
            contaChoque -= Time.deltaTime;
            if (contaChoque < 0)
            {
                MudaCor();
                DanoPlayer(1);
                contaChoque = 2;
            }
        }
        if (collision.gameObject.CompareTag("esteiraNeg"))
        {
            vel = 3f;
            retiraVel = 0.1f;
            transform.position += new Vector3(retiraVel, 0.0f, 0.0f);

        }
        if (collision.gameObject.CompareTag("esteiraPos"))
        {
            //vel = 8f;
            aumentaVel = -0.1f;
            transform.position += new Vector3(aumentaVel, 0.0f, 0.0f);


        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("laser") || collision.gameObject.CompareTag("Choque"))
        {
            contaChoque = 0;
        }
        if (collision.gameObject.CompareTag("esteiraNeg"))
        {
            vel = 5.5f;
            retiraVel = 0;
        }
        if (collision.gameObject.CompareTag("esteiraPos"))
        {
            vel = 5.5f;
            aumentaVel = 0;
        }
        if (collision.gameObject.CompareTag("Plataforma"))
        { 
            this.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Choque"))
        {
            contaChoque = 2;
        }
        if (collision.gameObject.CompareTag("parede"))
        {
            // dashAtivo = true;
            //speed = 25f;
            //speed2 = 40f;
        }
    }
       
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spawn"))
        {
            LastCheckpoint = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("mudaCena"))
        {
            //if (face)
            //{
            //    flip();
            //}
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       // if(collision.gameObject.CompareTag("Dialogo"))
     //   {
         //   vel = 0;
      //  }
        //else if (!collision.gameObject.CompareTag("Dialogo"))
        //{
        //    vel = 5.5f;
       // }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
       
      //  if (collision.gameObject.CompareTag("Dialogo"))
       // {
            //vel = 5.5f;
      //  }

    }
    void KnockBack(float poder)
    {
        iTween.MoveBy (gameObject, new Vector3(poder, 0, 0), 0.3f);
        iTween.ColorTo(gameObject, iTween.Hash("g", 0, "b", 0, "time", 0.05f, "looptype", iTween.LoopType.pingPong, "oncomplete","ParaEfeito"));
    }

    void MudaCor()
    {
        
        iTween.ColorTo(gameObject, iTween.Hash("g", 0, "b", 0, "time", 0.05f, "looptype", iTween.LoopType.pingPong, "oncomplete", "ParaEfeito"));
    }
    void VoltaCor()
    {
        iTween.ColorTo(gameObject, iTween.Hash("color", Color.white, "time", 0.1f));
    }
    IEnumerator ParaEfeito()
    {
        yield return tempo;
        iTween.Stop (gameObject,true);
        VoltaCor();
    }
   
}
