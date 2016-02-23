using UnityEngine;
using System.Collections;

public class abilityScript : MonoBehaviour
{
    public gameController controller;

    void activeAbility(gameController.Tile t)
    {
        Debug.Log("Active Ability");
    }

    void passiveAbility(gameController.Tile t)
    {
        Debug.Log("Passive Ability");
    }

}