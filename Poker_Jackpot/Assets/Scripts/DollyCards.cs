using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollyCards : MonoBehaviour
{
    public int[] DollyCardNumbers;
    public bool[] CardCanChangable;
    public bool DollyChance;
    public GameObject AllCards;
    [SerializeField] GameObject GameOverAndGameWinCanvas;
    [SerializeField] GameObject GamelostText;

    private void Start()
    {
        Invoke("SettingCardinDecesdingOrder", 1f);
        Invoke("DollyAi", 1.5f);
    }

    void SettingCardinDecesdingOrder()
    {
        int temp;
        for (int i = 0; i < DollyCardNumbers.Length; i++)
        {
            for (int j = i + 1; j < DollyCardNumbers.Length; j++)
            {
                if (DollyCardNumbers[i] < DollyCardNumbers[j])
                {
                    temp = DollyCardNumbers[i];
                    DollyCardNumbers[i] = DollyCardNumbers[j];
                    DollyCardNumbers[j] = temp;
                }
            }
        }
    }

    public int pickingCardNumber;
    private void Update()
    {
        SettingCardinDecesdingOrder();
        if(DollyChance)
        {
            picking();
            print(pickingCardNumber);
            AllCards.GetComponent<AllCards>().DollyChangeCard();
            DollyAi();
            DollyChance = false;
        }
    }

    private void picking()
    {
        int temp = UnityEngine.Random.Range(0, 4);
        if(CardCanChangable[temp])
        {
            pickingCardNumber =  DollyCardNumbers[temp];
        }
        else
        {
            picking();
        }
    }

    void DollyAi()
    {
       
        if ((DollyCardNumbers[0] == DollyCardNumbers[1] + 1) && (DollyCardNumbers[0] == DollyCardNumbers[2] + 2))
        {
            DollyWon();
        }
        else if ((DollyCardNumbers[3] == DollyCardNumbers[2] - 1) && (DollyCardNumbers[3] == DollyCardNumbers[1] - 2))
        {
            DollyWon();
        }
        else if (DollyCardNumbers[0] == DollyCardNumbers[1] + 1)
        {
            CardCanChangable[0] = false;
            CardCanChangable[1] = false;
            CardCanChangable[2] = true;
            CardCanChangable[3] = true;
        }
        else if (DollyCardNumbers[1] == DollyCardNumbers[2] + 1)
        {
            CardCanChangable[0] = true;
            CardCanChangable[1] = false;
            CardCanChangable[2] = false;
            CardCanChangable[3] = true;
        }
        else if (DollyCardNumbers[2] == DollyCardNumbers[3] + 1)
        {
            CardCanChangable[0] = true;
            CardCanChangable[1] = true;
            CardCanChangable[2] = false;
            CardCanChangable[3] = false;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                CardCanChangable[i] = true;
            }
        }
      
    }

    private void DollyWon()
    {
        GameOverAndGameWinCanvas.SetActive(true);
        GamelostText.GetComponent<Text>().text = "You lost....";
        print("Dolly_WonTheGame");
    }
}
