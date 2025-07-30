using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    public static List<bool> lamps = new List<bool>();

    public int levelsPassed;

    private void Awake()
    {
        for (int i = 0; i < LevelManager.totalLevelsGlobal; i++)
        {
            lamps.Add(false);
        }
    }

    private void Update()
    {
        if (LevelManager.currentLevel > levelsPassed)
        {
            levelsPassed = LevelManager.currentLevel;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(lamps[0]);
        }
    }
}
