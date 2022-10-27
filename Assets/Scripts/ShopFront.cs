using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFront : MonoBehaviour
{
    public Transform Player;
    public Transform EndLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.position = EndLocation.position;
    }
}
