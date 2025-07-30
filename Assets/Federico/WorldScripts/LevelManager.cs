using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel;

    public int totalLevels;

    public static int totalLevelsGlobal;

    private void Awake()
    {
        totalLevelsGlobal = totalLevels;
    }
}
