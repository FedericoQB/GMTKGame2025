using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerationScript : MonoBehaviour
{
    public GameObject backgroundPrefab;

    GameObject previousGenerated;


    // Start is called before the first frame update
    void Start()
    {
        
    }

#if UNITY_EDITOR
    void Generate()
    {
        
    }
#endif
}
