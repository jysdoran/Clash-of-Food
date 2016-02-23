using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
    Tile currentTile;
    Tile[,] tileGrid;

    public GameObject actionBar;
    int status; //0 = neutral, 1 = selected food, 2 = aiming ability, 3 = moving

    public class Tile
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
        //Setup tileGrid
        tileGrid = new Tile[3, 5];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                tileGrid[i, j] = new Tile(i, j);
            }
        }

        currentTile = null;
        addOccupant(tileGrid[1, 2], Resources.Load("Food"));

        addOccupant(tileGrid[2, 2], Resources.Load("Food"));

        actionBar.SetActive(false);
    }

    void Update()
    {

    }

    void addOccupant(Tile t, Object o)
    {
        t.occupant = Instantiate(o, new Vector3(t.i - 1, t.j - 2, 0) * 1.5f, transform.rotation) as GameObject;
    }

    public void setStatus(int s) //For interaction with ability/move buttons
    {
        status = s;
    }

    public void selectTile(int tile) //Called when a tile is clicked
    {
        Tile selectedTile = tileGrid[tile % 10, Mathf.FloorToInt(tile / 10)]; //Int -> array position

        if (selectedTile == currentTile)
        {
            status = 0;
        }
        else
        {
            if (status <= 1)
            {
                currentTile = selectedTile;
                
                if (currentTile.occupant != null)
                {
                    actionBar.SetActive(true);
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }
            else if (status == 2)
            {
                Debug.Log("Used ability at " + selectedTile.i + ", " + selectedTile.j);
                currentTile.occupant.GetComponent<foodBrain>().useActive(selectedTile);

                status = 0;
            }
            else if (status == 3)
            {
                if (selectedTile.occupant == null)
                {
                    addOccupant(selectedTile, currentTile.occupant);
                    Destroy(currentTile.occupant);
                    //currentTile.occupant = null;
                    status = 0;
                }
            }
        }

        if (status == 0)
        {
            actionBar.SetActive(false);
            currentTile = null;
        }
    }
}