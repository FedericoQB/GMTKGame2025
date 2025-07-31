using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject destinationEmpty;

    Vector3 originPos;

    [SerializeField] private float speed = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originPos = transform.position;
    }

    public void MoveToDestination()
    {
        transform.position = Vector2.MoveTowards(transform.position, destinationEmpty.transform.position, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 6);
    }

    public void MoveToOrigin()
    {
        transform.position = Vector2.MoveTowards(transform.position, originPos, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 6);
    }

    /*private void Update()
    {
        if (transform.position == originPos || transform.position == destinationEmpty.position)
        {
            rb.velocity = new Vector2();
        }
    }
    */
}
