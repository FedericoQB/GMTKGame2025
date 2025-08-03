using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceTorch : MonoBehaviour
{
    public Transform spawnTransform;
    public Transform spawnTransform2;
    public GameObject torchPrefab;

    public static int placedTorches;

    public void PlaceTorchInPosition()
    {
        Instantiate(torchPrefab, spawnTransform.position, Quaternion.identity);
        Instantiate(torchPrefab, spawnTransform2.position, Quaternion.identity);
        placedTorches += 2;
    }

    private void Update()
    {
        if (placedTorches >= 6)
        {
            ExitDoorScript.isOpen = true;
        }
    }

    public void Disable()
    {
        gameObject.GetComponent<PlaceTorch>().enabled = false;
    }
}
