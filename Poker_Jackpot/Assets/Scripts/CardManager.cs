using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] float stsrtPosX, startPosY;
    bool isheld = false;
    Vector3 CardOrginalPosition;
    private void Start()
    {
        CardOrginalPosition = gameObject.transform.position;
    }
    private void Update()
    {
        if (isheld &&(Input.GetMouseButton(0) || Input.GetMouseButton(1) ))
        {
            gameObject.GetComponent<Animator>().SetBool("isBeingHeld", isheld);
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isheld = false;
            gameObject.GetComponent<Animator>().SetBool("isBeingHeld", isheld);
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
