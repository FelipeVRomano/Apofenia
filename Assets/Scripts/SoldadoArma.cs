using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoldadoArma : MonoBehaviour
{

    public Transform Tiro12Baixo;
    public Transform Tiro12Cima;
    public Transform Tiro12Meio;
    public Transform TiroPist;
    public bool Arma12 = false;
    public bool ArmaPist = false;
    public float Tempo12 = 0.25f;
    public float TempoArmaPist = 0.25f;
    public float TiroCooldown;
    public AudioSource tiro;
    public AudioSource tiro2;

    // Start is called before the first frame update
    void Start()
    {
        TiroCooldown = 0;
      Physics2D.IgnoreLayerCollision(12, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if (TiroCooldown > 0)
        {

            TiroCooldown -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (PauseMenu.jogopausado == false && Dialogo.estaFalando == false && NewBehaviourScript.estaFalando3 == false)
        {
            if (Arma12 == true)
            {
                if (TiroCooldown <= 0)
                {

                    TiroCooldown = Tempo12;
                    var TiroTransform = Instantiate(Tiro12Baixo) as Transform;
                    TiroTransform.position = transform.position;
                    var TiroTransform2 = Instantiate(Tiro12Cima) as Transform;
                    TiroTransform2.position = transform.position;
                    var TiroTransform3 = Instantiate(Tiro12Meio) as Transform;
                    TiroTransform3.position = transform.position;
                    if (PauseMenu.jogopausado == false)
                    {
                        tiro.Play();
                    }
                }
            }

            if (ArmaPist == true)
            {
                if (TiroCooldown <= 0)
                {
                    TiroCooldown = TempoArmaPist;
                    var TiroTransform2 = Instantiate(TiroPist) as Transform;
                    TiroTransform2.position = transform.position;
                    if (PauseMenu.jogopausado == false)
                    {
                        tiro2.Play();
                    }
                }
            }
        }
    }
}
