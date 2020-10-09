using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArma : MonoBehaviour {

    public Transform TiroPist;
    public bool ArmaPist = true;  
    public float TempoArmaPist = 0.25f;
    public float TiroCooldown;

    public AudioSource tiro;
    public AudioSource tiro2;
    
    // Use this for initialization
    void Start ()
    {
        TiroCooldown = 0;
        ArmaPist = true;

    }

    // Update is called once per frame
    void Update ()
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
            if (ArmaPist == true)
            {
                if (TiroCooldown <= 0)
                {
                    TiroCooldown = TempoArmaPist;
                    var TiroTransform2 = Instantiate(TiroPist) as Transform;
                    TiroTransform2.position = transform.position;

                    tiro2.Play();

                }

            }



        }
    }
    
}
