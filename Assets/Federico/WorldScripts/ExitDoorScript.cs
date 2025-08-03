using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoorScript : MonoBehaviour
{
    public static bool isOpen;
    public UnityEvent unlockEvent;

    bool hasBeenActivated;

    [SerializeField] private int totalTorchesPlaced;


    private void Update()
    {
        totalTorchesPlaced = PlaceTorch.placedTorches;
        if (isOpen && !hasBeenActivated)
        {
            unlockEvent.Invoke();
            hasBeenActivated = true;
        }
    }
}
