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
        disablePanel();
        LeanTween.moveX(window, startLocation.position.x - 100, time).setEase(animationCurve2).setOnComplete(enablePanel);
    }

    //Opening the Panel
    public void Show()
    {
        panelShown = true;
        disablePanel();
        LeanTween.moveX(window, window.position.x + 100, time).setEase(animationCurve).setOnComplete(enablePanel);
    }

    private void disablePanel()
    {
        panelButton.enabled = false;
    }

    private void enablePanel()
    {
        panelButton.enabled = true;
    }
}
