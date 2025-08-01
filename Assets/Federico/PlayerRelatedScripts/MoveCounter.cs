using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCounter : MonoBehaviour
{
    public GameObject moveCounterObject;

    Image image;

    public List<Sprite> spritesInOrder = new List<Sprite>();

    int moveValue;


    // Start is called before the first frame update
    void Start()
    {
        image = moveCounterObject.GetComponent<Image>();

        spritesInOrder.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = Tracking.moves;

        image.sprite = spritesInOrder[moveValue];
    }
}
