using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappedOnThis : MonoBehaviour
{
    bool istApped = false;
    public bool TappicBool = false;
    [SerializeField] GameObject[] playercards;
    [SerializeField] GameObject playerMAnager;
    [SerializeField] GameObject Allcards;
    [SerializeField] GameObject Dolly;

    private void Update()
    {
        if (istApped && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            if(TappicBool && playerMAnager.GetComponent<PlayerCards>().playerchance)
            {
                print("Tapped");
                for (int i = 0; i < 4; i++)
                {
                    int index;
                    if(playercards[i].GetComponent<CardManager>().CardisSelected)
                    {
                        index = i;
                        Allcards.GetComponent<AllCards>().PlayerCardChange();
                        print(playerMAnager.GetComponent<PlayerCards>().Cardnumbers[i]);
                    }
                }
                //
                for (int i= 0;i<4;i++)
                {
                    playercards[i].GetComponent<CardManager>().CardisSelected = false;
                }
                TappicBool = false;
                //
                Dolly.GetComponent<DollyCards>().DollyChance = true;
            }
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);
        istApped = true;
    }
    private void OnMouseUp()
    {
        istApped = false;
    }

}
