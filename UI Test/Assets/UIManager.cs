using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class UIManager : MonoBehaviour
{
    public RectTransform window; //Set Panel here
    public AnimationCurve animationCurve;
    public AnimationCurve animationCurve2;
    private RectTransform startLocation;
    private Vector3 endLocation;
    public float time = 2f;
    private Button panelButton;
    private bool panelShown;

    void Start()
    {
        panelButton = window.GetComponent<Button>();
        startLocation = window; // Saves panel's location on game start - set its position first in Scene
        Debug.Log(startLocation);
        Show();
    }

    public void panelControl()
    {
        if (panelShown)
        {
            GoBack();
        }
        else
        {
            Show();
        }
    }

    //Closing the Panel
    public void GoBack()
    {
        panelShown = false;
        LeanTween.moveX(window, startLocation.position.x - 100, time).setEase(animationCurve2);
    }

    //Opening the Panel
    public void Show()
    {
        panelShown = true;
        LeanTween.moveX(window, window.position.x + 100, time).setEase(animationCurve).setOnComplete(setLocation);
    }

    private void setLocation()
    {
        endLocation = window.position;
        Debug.Log("EndLocation Set: " + endLocation);
    }
}
