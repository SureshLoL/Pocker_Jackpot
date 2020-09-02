using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCards : MonoBehaviour
{
    [SerializeField] Sprite[] Allcards;
    [SerializeField] Sprite Joker;
    [SerializeField] GameObject[] Card;
    [SerializeField] public Dictionary<int,Sprite> AllCArds;
    [SerializeField] GameObject PlayerCards;
    [SerializeField] GameObject DollyCars;
    public Sprite[] ShowAllRemingcards;
    public int[] SlecetdCardNumbers;
    [SerializeField] GameObject joker;
    [SerializeField] GameObject GameoverAndGAmewinCanvas;
    bool settingCanvas = false;
    [SerializeField] GameObject DrawTwxt;

    void Start()
    {
        AllCArds = new Dictionary<int, Sprite>();
        for (int i = 0; i < Allcards.Length; i++)
        {
            AllCArds.Add(i, Allcards[i]);
        }
        settingcards();
        Invoke("PlaerCardsCreating", 1f);
        Invoke("DollyCardsCreating", 1f);
        SettingRemainingCards();
    }

    private void SettingRemainingCards()
    {
        for(int i=0;i<5;i++)
        {
            ShowAllRemingcards[i] = AllCArds[cardnumbers[i]];
        }
    }

    [SerializeField] List<int> cardnumbers = new List<int>();
    void settingcards()
    {
        for (int i = 0; i < 8; i++)
        {
            int index = UnityEngine.Random.Range(0, cardnumbers.Count);
            SlecetdCardNumbers[i] = cardnumbers[index];
            cardnumbers.RemoveAt(index);
        }

    }


    private void PlaerCardsCreating()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = SlecetdCardNumbers[i];
            Card[i].GetComponent<SpriteRenderer>().sprite = Card[i].GetComponent<SpriteRenderer>().sprite = AllCArds[index]; 
            PlayerCards.GetComponent<PlayerCards>().Cards[i]= AllCArds[index];
            PlayerCards.GetComponent<PlayerCards>().Cardnumbers[i] = index;
        }
    }

    Sprite DontUsefulForDolly;
    void DollyCardsCreating()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = SlecetdCardNumbers[4 + i];
            DontUsefulForDolly = AllCArds[index];
            DollyCars.GetComponent<DollyCards>().DollyCardNumbers[i] = index;
            
        }
    }

    public void DollyChangeCard()
    {
        Invoke("DollypickingAi", 2f);
    }
    public int kk = 0;
    private void DollypickingAi()
    {
        kk++;
        print("D");
        for (int i = 0; i < 4; i++)
        {
            if (DollyCars.GetComponent<DollyCards>().pickingCardNumber == DollyCars.GetComponent<DollyCards>().DollyCardNumbers[i])
            {
                int index = UnityEngine.Random.Range(0, cardnumbers.Count - kk);
                int temp = DollyCars.GetComponent<DollyCards>().DollyCardNumbers[i];
                DollyCars.GetComponent<DollyCards>().DollyCardNumbers[i] = cardnumbers[index];
                cardnumbers[index] = -1;
                joker.GetComponent<SpriteRenderer>().sprite = AllCArds[temp];
                Invoke("PlayerTurn", 0.5f);
            }
        }
    }


    private void PlayerTurn()
    {
        PlayerCards.GetComponent<PlayerCards>().playerchance = true;
    }

    public void PlayerCardChange()
    {
        kk++;
        print("p");
        for (int i = 0; i < 4; i++)
        {
            if (Card[i].GetComponent<CardManager>().CardisSelected)
            {
                joker.GetComponent<SpriteRenderer>().sprite = AllCArds[PlayerCards.GetComponent<PlayerCards>().Cardnumbers[i]];
                int index = UnityEngine.Random.Range(0, cardnumbers.Count - kk);
                int temp = PlayerCards.GetComponent<PlayerCards>().Cardnumbers[i];
                PlayerCards.GetComponent<PlayerCards>().Cardnumbers[i] = cardnumbers[index];
                PlayerCards.GetComponent<PlayerCards>().Cards[i] = AllCArds[cardnumbers[index]];
                Card[i].GetComponent<SpriteRenderer>().sprite = AllCArds[cardnumbers[index]];
                cardnumbers[index] = -1;
                PlayerCards.GetComponent<PlayerCards>().playerchance = false;
            }
        }

    }

    private void Update()
    {
        if(kk == 5 && !settingCanvas)
        {
            print("CardsOver");
            GameoverAndGAmewinCanvas.SetActive(true);
            DrawTwxt.GetComponent<Text>().text = "It's a Draw...";
            settingCanvas = true;
        }
    }

}
