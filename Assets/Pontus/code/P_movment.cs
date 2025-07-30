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
    public static int maxMoves = 1000000;
    public static int shadowOrder = 1;
    public static int currentShadow = 1;
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


    public Vector2 movement;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    public GameObject Player;
    private Vector2 laserV2;
    public TextMeshProUGUI Moves;

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


        if (Input.GetKeyDown(KeyCode.W) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos, yPos + 1);
            Collider2D hit = Physics2D.OverlapPoint(laserV2, LayerMask.GetMask("ground"));
            if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos + 1);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                Tracking.moves--;
                Moves.text = Tracking.moves.ToString();
                Tracking.tracking.Add(1);
            }
            else
            {
                /*
                Player.transform.position = new Vector2(xPos, yPos + 1);
                Player.transform.rotation = Quaternion.Euler(180, 0, 0);
                moves--;
                Moves.text = moves.ToString();
                */
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos, yPos - 1);
            Collider2D hit = Physics2D.OverlapPoint(laserV2, LayerMask.GetMask("ground"));
            if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos, yPos - 1);
                Player.transform.rotation = Quaternion.Euler(180, 0, 0);
                Tracking.moves--;
                Moves.text = Tracking.moves.ToString();
                Tracking.tracking.Add(2);
            }
            else
            {
                /*
                Player.transform.position = new Vector2(xPos, yPos - 1);
                Player.transform.rotation = Quaternion.Euler(180, 0, 0);
                moves--;
                Moves.text = moves.ToString();
                */
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos + 1, yPos);
            Collider2D hit = Physics2D.OverlapPoint(laserV2, LayerMask.GetMask("ground"));
            if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos + 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 0, 270);
                Tracking.moves--;
                Moves.text = Tracking.moves.ToString();
                Tracking.tracking.Add(3);
            }
            else
            {
                /*
                Player.transform.position = new Vector2(xPos+1, yPos);
                Player.transform.rotation = Quaternion.Euler(180, 0, 0);
                moves--;
                Moves.text = moves.ToString();
                */
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && Tracking.moves > 0)
        {
            laserV2 = new Vector2(xPos - 1, yPos);
            Collider2D hit = Physics2D.OverlapPoint(laserV2, LayerMask.GetMask("ground"));
            if (hit == null || !hit.CompareTag(Tags.Wall))
            {
                Player.transform.position = new Vector2(xPos - 1, yPos);
                Player.transform.rotation = Quaternion.Euler(0, 0, 90);
                Tracking.moves--;
                Moves.text = Tracking.moves.ToString();
                Tracking.tracking.Add(4);
            }
            else
            {
                /*
                Player.transform.position = new Vector2(xPos - 1, yPos);
                Player.transform.rotation = Quaternion.Euler(180, 0, 0);
                moves--;
                Moves.text = moves.ToString();
                */
            }
        }

        if (Tracking.moves == 0) 
        {
            Player.transform.position = new Vector2 (ExitStuff.emptyExitGlobal.position.x,ExitStuff.emptyExitGlobal.position.y);
            Instantiate(shadow, Player.transform);
            Tracking.shadowOrder++;

        }
    }
}
