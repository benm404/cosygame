using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    /*Transform Player;
    ChatScript ChatScript;

    public GameObject chatscript;

    public bool Child = false;
    public bool Collected = false;
    float FollowDistance = 3f;
    float FollowSpeed = 0.04f;

    float PlayerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        ChatScript = chatscript.GetComponent<ChatScript>();
        Player = GameObject.Find("PlayerContainer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Vector3.Distance(Player.position, transform.position);
        
        if (Collected && ChatScript.Tagged && !ChatScript.Returned)
        {            
            if (PlayerPos >= FollowDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.position, FollowSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (ChatScript.Tagged)
        {
            if (!Child)
            {
                gameObject.SetActive(false);
                Collected = true;
            }
            else
            {
                Collected = true;
            }
        }
    }*/
}
