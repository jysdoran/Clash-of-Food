using UnityEngine;
using System.Collections;

public class foodBrain : MonoBehaviour
{
    gameController.Tile myTile;
    public gameController controller;

    public void useActive(gameController.Tile t)
    {
        BroadcastMessage("activeAbility",t);
    }

    public void usePassive(gameController.Tile t)
    {
        BroadcastMessage("passiveAbility",t);
    }

}