using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchWaveScript : MonoBehaviour
{
    public GameObject torchObject;

    Image image;

    public List<Sprite> spritesInOrder = new List<Sprite>();

    int moveValue = 0;

    [SerializeField] private float waitForSeconds = 1;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (torchObject == null)
        {
            torchObject = gameObject;
        }

        image = torchObject.GetComponent<Image>();

        spritesInOrder.Reverse();

        StartCoroutine(AnimateTorch());
    }

    private IEnumerator AnimateTorch()
    {
        while (true)
        {
            image.sprite = spritesInOrder[moveValue];

            moveValue++;
            if (moveValue >= spritesInOrder.Count)
            {
                moveValue = 0;
            }

            yield return new WaitForSecondsRealtime(waitForSeconds);
        }
    }
}
