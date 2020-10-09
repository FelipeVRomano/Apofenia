using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControle : MonoBehaviour
{
    public float TempoInicial = 0;
    public float TempoCount = 0;
    public Animator anim;
    public bool Tempo;
    public int Cria;
    public int AddTempo;
    public GameObject laser;
    public Transform criaLaser;
    public GameObject laserAtivar;
    [SerializeField]
    private float fixo1;
    [SerializeField]
    private float fixo2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Cria = 0;
        AddTempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tempo)
        {

            anim.SetBool("Off", true);
            anim.SetBool("Prep", false);
            anim.SetBool("On", false);
            AddTempo = 1;
        }
        if(TempoCount > fixo1)
        {
            Tempo = false;
            anim.SetBool("Off", false);
            anim.SetBool("Prep", true);
            anim.SetBool("On", false);
        }
        if (TempoCount > fixo2)
        {
            
            anim.SetBool("Off", false);
            anim.SetBool("Prep", false);
            anim.SetBool("On", true);
            Cria = 1;
            AddTempo = 0;
        }
        if(AddTempo ==1)
        {
            TempoCount += Time.deltaTime;
        }
        if(AddTempo == 0)
        {
            TempoCount = TempoInicial;
        }
        if (Cria == 1)
        {
            //GameObject Laser1 = Instantiate(laser, criaLaser.position, Quaternion.identity);
            laserAtivar.SetActive(true);
            Cria = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            laserAtivar.SetActive(false);
            Tempo = true;
        }
    }
    private void OnTriggerStay2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            laserAtivar.SetActive(false);
            Tempo = true;
        }
    }
}
