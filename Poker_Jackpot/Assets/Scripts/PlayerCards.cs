using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    public int[] Cardnumbers = {1,2,3,4};
    public Sprite[] Cards = new Sprite [4];
    public int[] orderCard;
    public bool playerchance = true;
    [SerializeField] GameObject GAmeOverAndGAmeWinCanvas,WinText;

    private void Start()
    {
        Invoke("settingOreder",2f);
    }

    void settingOreder()
    {
        for(int i=0;i<4;i++)
        {
            orderCard[i] = Cardnumbers[i];
        }
    }

    private void Update()
    {
        SettingCardinDecesdingOrder();
        CallWinScreen();
    }

    private void CallWinScreen()
    {
        Invoke("Winscreen", 5f);
    }

    private void Winscreen()
    {
        if((orderCard[0] == orderCard[1] + 1) && (orderCard[0] == orderCard[2] + 2) || (orderCard[3] == orderCard[2] - 1) && (orderCard[3] == orderCard[1] - 2))
        {
            GAmeOverAndGAmeWinCanvas.SetActive(true);
            WinText.GetComponent<Text>().text = "You Won.....";
        }
    }

    void SettingCardinDecesdingOrder()
    {
        int temp;
        for (int i = 0; i < orderCard.Length; i++)
        {
            for (int j = i + 1; j < orderCard.Length; j++)
            {
                if (orderCard[i] < orderCard[j])
                {
                    temp = orderCard[i];
                    orderCard[i] = orderCard[j];
                    orderCard[j] = temp;
                }
            }
        }
    }
}
