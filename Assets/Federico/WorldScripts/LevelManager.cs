using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool debugging;   
    [SerializeField, Range(0, 6)] private int testTorchAmount;

    public static int totalTorches;

    public List<GameObject> torches = new List<GameObject>();

    private void Start()
    {
        if (debugging)
        {
            totalTorches = testTorchAmount;
        }

        torches.Clear();

        torches.AddRange(GameObject.FindGameObjectsWithTag("Torch"));

        torches.Reverse();

        foreach (GameObject torch in torches)
        {
            torch.SetActive(false);
        }

        CheckTotalTorches();
    }

    void CheckTotalTorches()
    {
        if (totalTorches > 6)
        {
            totalTorches = 6;
        }

        for (int i = 0; i < totalTorches; i++)
        {
            torches[i].SetActive(true);
            torches[i].GetComponent<TorchWaveScript>().enabled = true;
        }
    }
}
