using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class Tags
{
    public const string Wall = "Wall";
}
public static class Tracking
{
    public static  List<int> tracking = new List<int>();
    public static int moves;
    public static int maxMoves = 10;
    public static int shadowOrder = 1;
    public static int currentShadow = 1;
    public static int boxMov = 0;
    public static bool reset = false;
    public static Vector2 chestPosision;
}

public class P_movment : MonoBehaviour
{
    public float speed;
    private float xPos;
    private float yPos;
    private bool hasSpawnedShadow = false;

    public Vector2 movement;
    Rigidbody2D rb;
    Camera cam;
    GameObject Player;
    private Vector2 laserV2;
    private Vector2 ChestlaserV2;
    public TextMeshProUGUI Moves;

    private Vector2 chestStartPos;

    public static Animator playerAnimator;
    public static bool isPlayingTeleAnimation;
    private Vector2 respanePiont;

    public GameObject Chest;
    private float ChestxPos;
    private float ChestyPos;


    public GameObject shadow;
    private void Start()
    {
        Tracking.moves = Tracking.maxMoves;
        Moves.text = Tracking.moves.ToString();

        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Player = gameObject;



        playerAnimator = GetComponent<Animator>();
        respanePiont = Player.transform.position;

    }
    private void Update()
    {
        Tracking.chestPosision = Chest.transform.position;
        xPos = Mathf.RoundToInt(Player.transform.position.x);
        yPos = Mathf.RoundToInt(Player.transform.position.y);
        ChestxPos = Mathf.RoundToInt(Chest.transform.position.x);
        ChestyPos = Mathf.RoundToInt(Chest.transform.position.y);
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Tracking.moves = 0;
        }
        if (Chester.cantakePos) 
        {
            chestStartPos = Chester.chestStartPosision;
            Debug.Log(chestStartPos + "chestpos23");
            Chester.cantakePos = false; 
        }
        if (TeleportScript.nextLevel) 
        {
            Tracking.tracking.Clear();
            TeleportScript.nextLevel = false;
        }

        // W = Up
        if (Input.GetKeyDown(KeyCode.W) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos, yPos + 1);
            Collider2D hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

            if (hit != null && hit.CompareTag("Chest"))
            {
                ChestlaserV2 = new Vector2(xPos, yPos + 2);
                Collider2D hitWall = Physics2D.OverlapPoint(ChestlaserV2/*, LayerMask.GetMask("ground")*/);

                if (hitWall == null || !hitWall.CompareTag(Tags.Wall))
                {
                    hit.transform.position = ChestlaserV2;
                    Player.transform.position = new Vector2(xPos, yPos + 1);
                    //Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Tracking.moves--;
                    Tracking.tracking.Add(1);
                    Chest.transform.position = new Vector2(ChestxPos, ChestyPos + 1);
                    //Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos + 1);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                Tracking.moves--;
                Tracking.tracking.Add(1);
            }
            Moves.text = Tracking.moves.ToString();
        }
        // S = Down
        if (Input.GetKeyDown(KeyCode.S) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos, yPos - 1);
            Collider2D hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

            if (hit != null && hit.CompareTag("Chest"))
            {
                ChestlaserV2 = new Vector2(xPos, yPos - 2);
                Collider2D hitWall = Physics2D.OverlapPoint(ChestlaserV2/*, LayerMask.GetMask("ground")*/);

                if (hitWall == null || !hitWall.CompareTag(Tags.Wall))
                {
                    hit.transform.position = ChestlaserV2;
                    Player.transform.position = new Vector2(xPos, yPos - 1);
                    //Player.transform.rotation = Quaternion.Euler(0, 0, 180);
                    Tracking.moves--;
                    Tracking.tracking.Add(2);
                    Chest.transform.position = new Vector2(ChestxPos, ChestyPos - 1);
                   // Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos - 1);
                //Player.transform.rotation = Quaternion.Euler(0, 0, 90);
                Tracking.moves--;
                Tracking.tracking.Add(2);
            }
            Moves.text = Tracking.moves.ToString();
        }

        // D = Right
        if (Input.GetKeyDown(KeyCode.D) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos + 1, yPos);
            Collider2D hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

            if (hit != null && hit.CompareTag("Chest"))
            {
                ChestlaserV2 = new Vector2(xPos + 2, yPos);
                Collider2D hitWall = Physics2D.OverlapPoint(ChestlaserV2/*, LayerMask.GetMask("ground")*/);

                if (hitWall == null || !hitWall.CompareTag(Tags.Wall))
                {
                    hit.transform.position = ChestlaserV2;
                    Player.transform.position = new Vector2(xPos + 1, yPos);
                    Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Tracking.moves--;
                    Tracking.tracking.Add(3);
                    Chest.transform.position = new Vector2(ChestxPos + 1, ChestyPos);
                    Chest.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos + 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                Tracking.moves--;
                Tracking.tracking.Add(3);
            }

            Moves.text = Tracking.moves.ToString();
        }
        // A = Left
        if (Input.GetKeyDown(KeyCode.A) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos - 1, yPos);
            Collider2D hit = Physics2D.OverlapPoint(laserV2/*, LayerMask.GetMask("ground")*/);

            if (hit != null && hit.CompareTag("Chest"))
            {
                ChestlaserV2 = new Vector2(xPos - 2, yPos);
                Collider2D hitWall = Physics2D.OverlapPoint(ChestlaserV2/*, LayerMask.GetMask("ground")*/);

                if (hitWall == null || !hitWall.CompareTag(Tags.Wall))
                {
                    hit.transform.position = ChestlaserV2;
                    Player.transform.position = new Vector2(xPos - 1, yPos);
                    Player.transform.rotation = Quaternion.Euler(0, 180, 0);
                    Tracking.moves--;
                    Tracking.tracking.Add(4);
                    Chest.transform.position = new Vector2(ChestxPos - 1, ChestyPos);
                    //Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos - 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
                Tracking.moves--;
                Tracking.tracking.Add(4);
            }

            Moves.text = Tracking.moves.ToString();
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Tracking.reset = true;
            Player.transform.position = respanePiont;
            Chest.transform.position = chestStartPos;
            StartCoroutine(ResetTimers());

        } 

        // When moves run out, spawn the shadow and reset
        if (Tracking.moves == 0 && !hasSpawnedShadow)
        {
            hasSpawnedShadow = true;
            Player.transform.position = respanePiont; // Optional: move player to reset point
            Instantiate(shadow, Player.transform.position, Player.transform.rotation);
            Tracking.shadowOrder++;
            Chest.transform.position = chestStartPos;


            StartCoroutine(timerss());

        }
    }
    IEnumerator timerss()
    {


        yield return new WaitForSeconds(0.2f);
        Tracking.moves = Tracking.maxMoves;
        Moves.text = Tracking.moves.ToString();
        hasSpawnedShadow = false;
    }
    IEnumerator ResetTimers()
    {


        yield return new WaitForSeconds(0.2f);
        Tracking.reset = false;
    }

}
