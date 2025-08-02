using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sadow_Mov : MonoBehaviour
{
    private List<int> shadowList;
    public GameObject Shadow;
    private Vector2 laserV2;
    private Vector2 chestLaserV2;

     GameObject Chest;
    private float ChestxPos;
    private float ChestyPos;
    private bool canStart = false;
    private Vector2 startPos;

    private bool hasTriggered = false;

    public Animator shadowAnimator;
    public bool isPlayingTeleAnimation;

    private void Start()
    {
        shadowList = new List<int>(Tracking.tracking);
        Tracking.tracking.Clear();
        Chest = GameObject.FindGameObjectWithTag("Chest");
        startPos = Shadow.transform.position;
        canStart = true;


        shadowAnimator = GetComponent<Animator>();
    }

    private void Update()
    {

        if(Tracking.moves == 0 &&  canStart && !hasTriggered) 
        {
            hasTriggered = true;
            Shadow.transform.position = startPos;

            StartCoroutine(PlayShadowMoves());

            canStart = false;
            
        }
        if (Tracking.reset)
        {

            Destroy(gameObject);
        }
    }
    IEnumerator PlayShadowMoves()
    {
        for (int i = 0; i < shadowList.Count; i++)
        {
            float xPos = Mathf.RoundToInt(Shadow.transform.position.x);
            float yPos = Mathf.RoundToInt(Shadow.transform.position.y);
            int move = shadowList[i];

            ChestxPos = Mathf.RoundToInt(Chest.transform.position.x);
            ChestyPos = Mathf.RoundToInt(Chest.transform.position.y);

            switch (move)
            {
                case 1: // Up
                    laserV2 = new Vector2(xPos, yPos + 1);
                    Collider2D hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

                    if (hit != null && hit.CompareTag("Chest"))
                    {
                        chestLaserV2 = new Vector2(xPos, yPos + 2);
                        Collider2D chestHitWall = Physics2D.OverlapPoint(chestLaserV2/*, LayerMask.GetMask("ground")*/);

                        if (chestHitWall == null || !chestHitWall.CompareTag(Tags.Wall))
                        {
                            Shadow.transform.position = new Vector2(xPos , yPos +1);
                            //Shadow.transform.rotation = Quaternion.Euler(0, 0, 180);
                            Chest.transform.position = new Vector2(ChestxPos , ChestyPos + 1);
                            //Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                    }

                    else if (hit == null || !hit.CompareTag(Tags.Wall))
                    {
                        Shadow.transform.position = new Vector2(xPos, yPos + 1);
                        //Shadow.transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                    break;

                case 2: // Down
                    laserV2 = new Vector2(xPos, yPos - 1);
                    hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

                    if (hit != null && hit.CompareTag("Chest"))
                    {
                        chestLaserV2 = new Vector2(xPos, yPos - 2);
                        Collider2D chestHitWall = Physics2D.OverlapPoint(chestLaserV2/*, LayerMask.GetMask("ground")*/);

                        if (chestHitWall == null || !chestHitWall.CompareTag(Tags.Wall))
                        {
                            Shadow.transform.position = new Vector2(xPos , yPos - 1);
                            //Shadow.transform.rotation = Quaternion.Euler(0, 0, 180);
                            Chest.transform.position = new Vector2(ChestxPos, ChestyPos - 1);
                            //Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                    }

                    else if (hit == null || !hit.CompareTag(Tags.Wall))
                    {
                        Shadow.transform.position = new Vector2(xPos, yPos - 1);
                        //Shadow.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    break;

                case 3: // Right
                    laserV2 = new Vector2(xPos + 1, yPos);
                    hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

                    if (hit != null && hit.CompareTag("Chest"))
                    {
                        chestLaserV2 = new Vector2(xPos + 2, yPos);
                        Collider2D chestHitWall = Physics2D.OverlapPoint(chestLaserV2/*, LayerMask.GetMask("ground")*/);

                        if (chestHitWall == null || !chestHitWall.CompareTag(Tags.Wall))
                        {
                            Shadow.transform.position = new Vector2(xPos + 1, yPos);
                            Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                            Chest.transform.position = new Vector2(ChestxPos + 1, ChestyPos);
                            Chest.transform.rotation = Quaternion.Euler(0, 0, 0);

                        }
                    }

                    else if (hit == null || !hit.CompareTag(Tags.Wall))
                    {
                        Shadow.transform.position = new Vector2(xPos + 1, yPos);
                        Shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    break;

                case 4: // Left
                    laserV2 = new Vector2(xPos - 1, yPos);
                    hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

                    if (hit != null && hit.CompareTag("Chest"))
                    {
                        chestLaserV2 = new Vector2(xPos - 2, yPos);
                        Collider2D chestHitWall = Physics2D.OverlapPoint(chestLaserV2/*, LayerMask.GetMask("ground")*/);

                        if (chestHitWall == null || !chestHitWall.CompareTag(Tags.Wall))
                        {
                            Shadow.transform.position = new Vector2(xPos - 1, yPos);
                            Shadow.transform.rotation = Quaternion.Euler(0, 180, 0);
                            Chest.transform.position = new Vector2(ChestxPos - 1, ChestyPos);
                            Chest.transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                    }

                    else if (hit == null || !hit.CompareTag(Tags.Wall)) 
                    {
                        Shadow.transform.position = new Vector2(xPos - 1, yPos);
                        Shadow.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        canStart = true;
        hasTriggered = false;
    }
}