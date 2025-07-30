using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivationScript : MonoBehaviour
{
    public int lampIndex;

    public void ActivateLamp()
    {
        ExitDoorScript.lamps[lampIndex] = true;
    }

    public void DeactivateLamp()
    {
        ExitDoorScript.lamps[lampIndex] = false;
    }
}
