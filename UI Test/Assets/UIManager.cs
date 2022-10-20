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

    void Start()
    {
        panelButton = window.GetComponent<Button>();
        startLocation = window; // Saves panel's location on game start - set its position first in Scene
        Debug.Log(startLocation);
        Show();
    }

    //Closing the Panel
    public void GoBack()
    {
        LeanTween.moveX(window, startLocation.position.x - 120, time).setEase(animationCurve2);
        panelButton.enabled = true;
    }

    //Opening the Panel
    public void Show()
    {
        LeanTween.moveX(window, window.position.x + 120, time).setEase(animationCurve).setOnComplete(setLocation);
        panelButton.enabled = false; //Prevents you from clicking on panel to move panel forward infinitely
    }

    private void setLocation()
    {
        endLocation = window.position;
        Debug.Log("EndLocation Set: " + endLocation);
    }
}
