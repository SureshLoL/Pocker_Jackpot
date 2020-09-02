using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] float stsrtPosX, startPosY;
    bool isheld = false;
    public bool CardisSelected;
    [SerializeField] GameObject[] Cards;
    [SerializeField] GameObject TappingObject;

   
    private void Update()
    {
        if (isheld &&(Input.GetMouseButton(0) || Input.GetMouseButton(1) ))
        {
            for(int i=0;i<4;i++)
            {
                Cards[i].GetComponent<CardManager>().CardisSelected = false;
            }
            CardisSelected = true;
            gameObject.GetComponent<Animator>().SetBool("isBeingHeld", isheld);
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isheld = false;
            gameObject.GetComponent<Animator>().SetBool("isBeingHeld", isheld);
        }
        if(CardisSelected)
        {
            TappingObject.GetComponent<TappedOnThis>().TappicBool = true;
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);
        isheld = true;
    }
    private void OnMouseUp()
    {
        isheld = false;
    }

}
