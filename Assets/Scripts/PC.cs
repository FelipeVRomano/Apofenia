using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    [SerializeField]
    private bool visaoX;
    [SerializeField]
    private float raioX;
    [SerializeField]
    private LayerMask layerX;
    [SerializeField]
    private SpriteRenderer Xrender;

    public Animator aniX;




    // Start is called before the first frame update
    void Start()
    {
        Xrender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        visaoX = Physics2D.OverlapCircle(transform.position, raioX, layerX);


        if (visaoX) { 
            aniX.SetBool("PlayerNaArea", true);
        
           
        }

        else
        {
            aniX.SetBool("PlayerNaArea", false);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioX);
    }
}
