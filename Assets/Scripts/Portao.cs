using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Destroy(gameObject);
                
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Destroy(gameObject);

            }
        }
    }

}
