using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnd : MonoBehaviour
{
    public Transform ReturnLocation;
    public Transform Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.position = ReturnLocation.position;
    }
}
