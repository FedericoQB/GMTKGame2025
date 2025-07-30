using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sadow_Mov : MonoBehaviour
{
    private List<int> shadowList;
    private int thisShadowOrder = Tracking.shadowOrder;
    public GameObject Shadow;
    private float xPos;
    private float yPos;
    private bool canMove = true;


    private void Start()
    {
        shadowList = new List<int>(Tracking.tracking);
        Tracking.tracking.Clear();

        StartCoroutine(PlayShadowMoves());
    }

    IEnumerator PlayShadowMoves()
    {
        for (int i = 0; i < shadowList.Count; i++)
        {
            float xPos = Mathf.RoundToInt(Shadow.transform.position.x);
            float yPos = Mathf.RoundToInt(Shadow.transform.position.y);

            int move = shadowList[i];

            // Apply movement based on recorded direction
            switch (move)
            {
                case 1: // Up
                    Shadow.transform.position = new Vector2(xPos, yPos + 1);
                    Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 2: // Down
                    Shadow.transform.position = new Vector2(xPos, yPos - 1);
                    Shadow.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case 3: // Right
                    Shadow.transform.position = new Vector2(xPos + 1, yPos);
                    Shadow.transform.rotation = Quaternion.Euler(0, 0, 270);
                    break;
                case 4: // Left
                    Shadow.transform.position = new Vector2(xPos - 1, yPos);
                    Shadow.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }

            yield return new WaitForSeconds(0.5f); // Wait between moves
        }
    }
}






























   /* private void Update()
    {
        xPos = Mathf.RoundToInt(Shadow.transform.position.x);
        yPos = Mathf.RoundToInt(Shadow.transform.position.y);

        if (/*thisShadowOrder == Tracking.currentShadow true ) 
        {
            Debug.Log(shadowList.Count);
            for(int i = 0; i < shadowList.Count; i++) 
            {
                if (canMove) 
                {
                    canMove = false;
                    if (shadowList[i] == 1)
                    {
                        Shadow.transform.position = new Vector2(xPos, yPos + 1);
                        Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (shadowList[i] == 2)
                    {
                        Shadow.transform.position = new Vector2(xPos, yPos - 1);
                        Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (shadowList[i] == 3)
                    {
                        Shadow.transform.position = new Vector2(xPos + 1, yPos);
                        Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (shadowList[i] == 4)
                    {
                        Shadow.transform.position = new Vector2(xPos - 1, yPos);
                        Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    StartCoroutine( WaitForXseconds());
                    canMove = true;
                }
            }
            Tracking.currentShadow = thisShadowOrder++;
        }
    }
    IEnumerator WaitForXseconds() 
    {
        yield return new WaitForSeconds(2f);

    }*/

