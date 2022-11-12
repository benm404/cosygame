using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HouseDialogue : MonoBehaviour
{
    GameManager GameManager;
    MovementScript Move;

    public GameObject NoteBackground;
    public GameObject Text0;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;

    public GameObject Tooltip;

    public bool NoteActive = false;
    public int Timer;
    private int Time = 10;
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Move = GameObject.Find("PlayerContainer").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Timer >= 0)
        {
            Timer -= 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MainHouse"))
        {
            Tooltip.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MainHouse"))
        {
            Tooltip.SetActive(true);
        }
        
        if(Input.GetKey(KeyCode.E) && collision.CompareTag("MainHouse") && Timer <= 0)
        {
            Timer = Time;
            if (!GameManager.LitterCollected)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text0);
                } else { HideNote(Text0); }
            }
            if(GameManager.LitterCollected && !GameManager.RaceWon)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text1);
                }
                else { HideNote(Text1); }
            }
            if(GameManager.RaceWon && !GameManager.RockKeyCollected)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text2);
                }
                else { HideNote(Text2); }
            }
            if(GameManager.RockKeyCollected && !GameManager.PhotoViewed)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text3);
                }
                else { HideNote(Text3); }
            }
            if(GameManager.PhotoViewed && !GameManager.FinalKeyCollected)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text4);
                }
                else { HideNote(Text4); }
            }
            if (GameManager.FinalKeyCollected)
            {
                if (!NoteActive)
                {
                    print("Turn on");
                    DisplayNote(Text5);
                }
                else { HideNote(Text5); }
            }
        }
    }

    private void DisplayNote(GameObject text)
    {
        NoteActive = true;
        NoteBackground.SetActive(true);
        text.SetActive(true);
        Move.MovementActive = false;
    }

    private void HideNote(GameObject text)
    {
        NoteActive = false;
        NoteBackground.SetActive(false);
        text.SetActive(false);
        Move.MovementActive = true;
    }
}
