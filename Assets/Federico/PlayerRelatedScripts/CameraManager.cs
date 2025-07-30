using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera camera;

    public List<Transform> cameraPositions = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }
}
