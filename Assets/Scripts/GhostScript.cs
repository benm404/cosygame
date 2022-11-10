using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public TextMeshProUGUI StartText;
    public TextMeshProUGUI FailText;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI RaceStart;
    public GameObject TextBox;

    public Vector3 PlayerPosition;
    public Vector3 StartPosition;
    public Vector3 EndPosition;

    public float speed;

    public int TimeDefault;
    public int Timer;
    public bool StartTimer = false;

    public float RaceTime;

    public bool StartRaceBool = false;

    public bool GhostWin = false;
    public bool PlayerWin = false;
    public bool RaceOver = false;

    private GameManager GameManager;
    private MovementScript MovementScript;
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MovementScript = GameObject.Find("PlayerContainer").GetComponent<MovementScript>();
        Timer = TimeDefault;
    }


    void Update()
    {
        float step = speed * Time.deltaTime;
        if (GameManager.LitterCollected)
        {
            gameObject.SetActive(true);
        }

        if (Timer <= 0)
        {
            HideText(StartText);
            HideText(WinText);
            HideText(FailText);
        }

        if (StartRaceBool && !StartText.gameObject.activeInHierarchy)
        {
            if(RaceTime >= 0.1f)
            {
                RaceStart.gameObject.SetActive(true);
                RaceTime -= Time.deltaTime;
                DisplayTime(RaceTime);
            }
            else
            {
                RaceTime = 0;
                RaceStart.gameObject.SetActive(false);
                MovementScript.MovementActive = true;
            }

            if (RaceTime <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPosition, step);
            }
        }

        


        if(RaceOver && PlayerWin && StartRaceBool)
        {
            DisplayText(WinText);
            GameManager.RaceWon = true;
            StartRaceBool = false;
        }

        if(RaceOver && GhostWin && StartRaceBool)
        {
            DisplayText(FailText);
            
            StartRaceBool = false;
            GhostWin = false;
        }
        if(RaceOver && !PlayerWin && !FailText.gameObject.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPosition, step);
            RaceTime = 4;
        }
        if(transform.position == StartPosition)
        {
            RaceOver = false;
        }
    }

    private void FixedUpdate()
    {
        if (StartTimer)
        {
            Timer -= 1;
        } else { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !GameManager.RaceWon)
        {
            MovementScript.MovementActive = false;
            collision.transform.position = PlayerPosition;
            DisplayText(StartText);
            StartRaceBool = true;
        }
    }

    private void DisplayText(TextMeshProUGUI text)
    {
        StartTimer = true;
        text.gameObject.SetActive(true);
        TextBox.SetActive(true);
    }

    private void HideText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(false);
        TextBox.SetActive(false);
        StartTimer = false;
        Timer = TimeDefault;
    }

    void DisplayTime(float time)
    {
        if(time < 0)
        {
            time = 0;
        }

        float timeRemaining = Mathf.FloorToInt(time);
        RaceStart.text = string.Format("{0:0}", timeRemaining);
    }
}
