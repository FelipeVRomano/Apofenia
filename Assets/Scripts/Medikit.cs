using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medikit : MonoBehaviour
{
    public int cura = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           
                Player vida = collider.gameObject.GetComponent<Player>();
                if (vida != null)
                {
                if (Player.HP < 3)
                {
                    vida.CuraPlayer(cura);
                    Destroy(gameObject);

                }
            }

            

        }
    }
}
