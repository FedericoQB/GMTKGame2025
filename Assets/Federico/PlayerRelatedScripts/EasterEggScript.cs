using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggScript : MonoBehaviour
{
    public GameObject easterObject;

    public float seconds;

    private static bool hasPlayed;

    public void OnActivated()
    {
        if (!hasPlayed) StartCoroutine(WaitForAFewSeconds());
    }

    private IEnumerator WaitForAFewSeconds()
    {
        yield return null;

        easterObject.SetActive(true);

        yield return new WaitForSecondsRealtime(seconds);

        easterObject.SetActive(false);
    }
}
