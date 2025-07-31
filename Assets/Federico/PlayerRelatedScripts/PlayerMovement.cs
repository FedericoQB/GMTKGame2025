using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed;

    private float horizontalInput;
    private float verticalInput;

    public float timer;
    private float startTimer;

    private bool hasMoved;

    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (rb.velocity != new Vector2())
        {
            hasMoved = true;
        }

        if (hasMoved) CountDown();

        if (timer <= 0)
        {
            ResetPlayer();
        }
    }

    private void CountDown()
    {
        timer -= Time.deltaTime;
    }

    private void ResetPlayer()
    {
        transform.position = spawnLocation.position;
        rb.velocity = new Vector2();
        hasMoved = false;
        timer = startTimer;
    }
}
