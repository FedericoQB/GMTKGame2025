using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    int buildIndex;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (buildIndex < 8)
            {
                LevelManager.totalTorches++;
                SceneManager.LoadScene(buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(8);
            }
        }

        if (buildIndex == 0)
        {
            LevelManager.totalTorches = 0;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(7);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
