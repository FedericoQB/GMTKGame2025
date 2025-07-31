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
}

public class P_movment : MonoBehaviour
{
    public float speed;
    private float movementSpeed;
    private float movementSpeed07;
    private float OrgMovementSpeed;
    private bool isDiagonal = false;
    private float xPos;
    private float yPos;
    private bool hasSpawnedShadow = false;

    public Vector2 movement;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    public GameObject Player;
    private Vector2 laserV2;
    private Vector2 ChestlaserV2;
    public TextMeshProUGUI Moves;

    public GameObject Chest;
    private float ChestxPos;
    private float ChestyPos;

    public GameObject shadow;
    private void Start()
    {
        OrgMovementSpeed = speed;  // Store original speed
        movementSpeed = speed;     // Set movementSpeed to the original speed
        movementSpeed07 = speed * 0.6f;  // Set diagonal movement speed (60% of the normal speed)
        Tracking.moves = Tracking.maxMoves;
        Moves.text = Tracking.moves.ToString();

    }
    private void Update()
    {
        xPos = Mathf.RoundToInt(Player.transform.position.x);
        yPos = Mathf.RoundToInt(Player.transform.position.y);
        ChestxPos = Mathf.RoundToInt(Chest.transform.position.x);
        ChestyPos = Mathf.RoundToInt(Chest.transform.position.y);

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
                    Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Tracking.moves--;
                    Tracking.tracking.Add(1);
                    Chest.transform.position = new Vector2(ChestxPos, ChestyPos + 1);
                    Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos + 1);
                Player.transform.rotation = Quaternion.Euler(0, 0, 270);
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
                    Player.transform.rotation = Quaternion.Euler(0, 0, 180);
                    Tracking.moves--;
                    Tracking.tracking.Add(2);
                    Chest.transform.position = new Vector2(ChestxPos, ChestyPos - 1);
                    Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos - 1);
                Player.transform.rotation = Quaternion.Euler(0, 0, 90);
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
                    Player.transform.rotation = Quaternion.Euler(0, 0, 270);
                    Tracking.moves--;
                    Tracking.tracking.Add(3);
                    Chest.transform.position = new Vector2(ChestxPos + 1, ChestyPos);
                    Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos + 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 0, 270);
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
                    Player.transform.rotation = Quaternion.Euler(0, 0, 90);
                    Tracking.moves--;
                    Tracking.tracking.Add(4);
                    Chest.transform.position = new Vector2(ChestxPos - 1, ChestyPos);
                    Chest.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos - 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 0, 90);
                Tracking.moves--;
                Tracking.tracking.Add(4);
            }

            Moves.text = Tracking.moves.ToString();
        }

        // When moves run out, spawn the shadow and reset
        if (Tracking.moves == 0 && !hasSpawnedShadow)
        {
            hasSpawnedShadow = true;
            Player.transform.position = new Vector2(0, 0); // Optional: move player to reset point
            Instantiate(shadow, Player.transform.position, Player.transform.rotation);
            Tracking.shadowOrder++;
           

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

}
