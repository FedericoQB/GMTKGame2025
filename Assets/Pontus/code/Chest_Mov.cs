using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Chester 
{
    public static Vector2 chestStartPosision;
    public static bool cantakePos = false;
}
public class Chest_Mov : MonoBehaviour
{
    private void Start()
    {
        Chester.chestStartPosision = gameObject.transform.position;
        Debug.Log(gameObject.transform.position + "chestPos1");
        Chester.cantakePos = true;
    }
    private void Update()
    {
        if (Tracking.reset)
        {
            gameObject.transform.position = Chester.chestStartPosision;
            Debug.Log(Chester.chestStartPosision);
        }
    }
}
