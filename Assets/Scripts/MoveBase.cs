using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 posC;
 
    private Vector3 nexPos;

    [SerializeField]

    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    public Transform transformB;
    public Transform transformC;

    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        posC = transformC.localPosition;
        nexPos = posB;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
    private void Update()
    {
        Move();
    }


    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posC ? posC : posB;
    }
}

