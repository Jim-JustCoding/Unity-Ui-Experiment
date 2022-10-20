using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class UIManager : MonoBehaviour
{
    public RectTransform window;
    public AnimationCurve animationCurve;
    public AnimationCurve animationCurve2;
    private Vector3 startLocation;
    private Vector3 endLocation;
    public float time = 2f;

    void Start()
    {
        startLocation = window.position;
        Debug.Log(startLocation);
        Show();
    }

    public void GoBack()
    {
        LeanTween.moveX(window, transform.position.x - 130f, time).setEase(animationCurve2);
    }

    public void Show()
    {
        LeanTween.moveX(window, transform.position.x, time).setEase(animationCurve).setOnComplete(setLocation);
    }

    private void showMsg()
    {
        Debug.Log("Hello");
    }

    private void setLocation()
    {
        endLocation = window.position;
        Debug.Log("EndLocation Set: " + endLocation);
    }
}
