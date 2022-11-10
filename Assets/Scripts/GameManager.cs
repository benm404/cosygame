using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public GameObject TextBox;
    
    public TextMeshProUGUI Litter;
    private GameObject LitterContainer;

    public int Time;
    [SerializeField]private int LitterTimer;
    private bool StartTimer = false;
    private bool LitterCollected = false;

    private void Start()
    {
        LitterContainer = GameObject.Find("Litter");
        LitterTimer = Time;
    }

    private void Update()
    {
        if(LitterContainer.transform.childCount <= 0)
        {
            LitterCollected = true;
            if (LitterTimer >= 0)
            {
                DisplayText(Litter);
            }
            if(LitterTimer <= 0)
            {
                HideText(Litter);
            }
        }
    }

    private void FixedUpdate()
    {
        if (LitterCollected)
        {
            LitterTimer -= 1;
        }
        
    }

    private void DisplayText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        TextBox.SetActive(true);
    }

    private void HideText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(false);
        TextBox.SetActive(false);
    }
}
