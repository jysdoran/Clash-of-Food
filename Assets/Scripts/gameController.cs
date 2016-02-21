using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
    Tile currentTile;
    Tile[,] tileGrid;

    class Tile
    {
        public GameObject occupant;
        public int i;
        public int j;

        public Tile(int x, int y)
        {
            i = x;
            j = y;
        }
    }

    void Start()
    {
        tileGrid = new Tile[3,5];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                tileGrid[i, j] = new Tile(i,j);
            }
        }

        currentTile = tileGrid[1, 2];
        addOccupant(currentTile, Resources.Load("Food"));
    }

    void Update()
    {

    }

    void addOccupant(Tile t, Object o)
    {
        t.occupant = Instantiate(o, new Vector3(t.i - 1,t.j - 2,0) * 1.5f, transform.rotation) as GameObject;
    }

    public void selectTile(int tile)
    {
        currentTile = tileGrid[tile % 10,Mathf.FloorToInt(tile/10)]; //Int -> array position

        addOccupant(currentTile, Resources.Load("Food"));
    }
}