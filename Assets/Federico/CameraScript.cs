using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Camera;
    public Transform player;

    private float CameraSpeed;
    public float playerSpeed;

    private float cameraSag = 1.5f;

    private float lockedZ = -10f;

    private void Start()
    {
        Camera = gameObject.transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 currentPosition = Camera.position;
        currentPosition.z = lockedZ;
        Camera.position = currentPosition;
        var PosDif = Vector2.Distance(Camera.position, player.position);
        CameraSpeed = (playerSpeed * cameraSag) * PosDif;
        Camera.position = Vector3.MoveTowards(Camera.position, player.position, CameraSpeed * Time.deltaTime);
    }
}
