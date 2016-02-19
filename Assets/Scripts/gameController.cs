using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
    public int currentTile;


    void Start()
    {
        currentTile = 0;
    }

    void Update()
    {

    }



    public void selectTile (int tile)
    {
        currentTile = tile;
        Debug.Log(currentTile);
    }
}