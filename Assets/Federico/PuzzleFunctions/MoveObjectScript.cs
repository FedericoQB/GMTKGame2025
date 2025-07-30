using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform destinationEmpty;

    [SerializeField] private float speed = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToDestination()
    {
        rb.velocity = (transform.position - destinationEmpty.transform.position).normalized;
    }

    private void Update()
    {

    }
}
