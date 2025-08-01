using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Chester 
{
    public static Vector2 chestStartPosision;
}
public class Chest_Mov : MonoBehaviour
{
    private void Start()
    {
        Chester.chestStartPosision = gameObject.transform.position;
    }
    private void Update()
    {
        if (Tracking.reset)
            gameObject.transform.position = Chester.chestStartPosision;
    }
}
