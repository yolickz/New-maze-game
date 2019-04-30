using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour
{
    public int mazeRows, mazeColumns;
    public GameObject wall;
    public GameObject floor;
    public GameObject player;
    public GameObject Powerup;
    public GameObject SpeedUp;
    int powerups = 50;
    public float size = 2f;

    private MazeCell[,] mazeCells;

    // Use this for initialization
    void Start()
    {
        Spawns();
        InitializeMaze();

        MazeAlgorithm ma = new HuntAndKillMazeAlgorithm(mazeCells);
        ma.CreateMaze();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void Spawns()
    {
        //Instantiate(player, new Vector3(0, -0.75f, 0), Quaternion.identity);
        for (int i = 0; i < powerups; i++)
        {
            Instantiate(Powerup, new Vector3(Random.Range(10, 308), -1.5f, Random.Range(5, 145)), Quaternion.identity);
            Instantiate(SpeedUp, new Vector3(Random.Range(10, 308), -1.5f, Random.Range(5, 145)), Quaternion.identity);
        }
        /*
        //BL
        for (int i = 0; i < powerups/4; i++)
        {
            Instantiate(Powerup, new Vector3(Random.Range(0,160),-1.5f, Random.Range(0, 75)), Quaternion.identity);
            Instantiate(SpeedUp, new Vector3(Random.Range(0, 160), -1.5f, Random.Range(0, 75)), Quaternion.identity);
        }
        //TL
        for (int i = 0; i < powerups / 4; i++)
        {
            Instantiate(Powerup, new Vector3(Random.Range(140, 318), -1.5f, Random.Range(0, 75)), Quaternion.identity);
            Instantiate(SpeedUp, new Vector3(Random.Range(140, 318), -1.5f, Random.Range(0, 75)), Quaternion.identity);
        }
        //BR
        for (int i = 0; i < powerups / 4; i++)
        {
            Instantiate(Powerup, new Vector3(Random.Range(0, 160), -1.5f, Random.Range(76, 150)), Quaternion.identity);
            Instantiate(SpeedUp, new Vector3(Random.Range(0, 160), -1.5f, Random.Range(76, 150)), Quaternion.identity);
        }
        //TR
        for (int i = 0; i < powerups / 4; i++)
        {
            Instantiate(Powerup, new Vector3(Random.Range(140, 318), -1.5f, Random.Range(76, 150)), Quaternion.identity);
            Instantiate(SpeedUp, new Vector3(Random.Range(140, 318), -1.5f, Random.Range(76, 150)), Quaternion.identity);
        }
        */
    }

    private void InitializeMaze()
    {

        mazeCells = new MazeCell[mazeRows, mazeColumns];

        for (int r = 0; r < mazeRows; r++)
        {
            for (int c = 0; c < mazeColumns; c++)
            {
                mazeCells[r, c] = new MazeCell();

                // For now, use the same wall object for the floor!
                mazeCells[r, c].floor = Instantiate(floor, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].floor.name = "Floor " + r + "," + c;
                mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

                if (c == 0)
                {
                    mazeCells[r, c].westWall = Instantiate(wall, new Vector3(r * size, -1.5f, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].westWall.name = "West Wall " + r + "," + c;
                }

                mazeCells[r, c].eastWall = Instantiate(wall, new Vector3(r * size, -1.5f, (c * size) + (size / 2f)), Quaternion.identity) as GameObject;
                mazeCells[r, c].eastWall.name = "East Wall " + r + "," + c;

                if (r == 0)
                {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), -1.5f, c * size), Quaternion.identity) as GameObject;
                    mazeCells[r, c].northWall.name = "North Wall " + r + "," + c;
                    mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);
                }

                mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), -1.5f, c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].southWall.name = "South Wall " + r + "," + c;
                mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);
            }
        }
    }
}
