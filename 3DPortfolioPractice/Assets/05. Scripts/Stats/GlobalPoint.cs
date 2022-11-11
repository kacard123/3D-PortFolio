using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalPoint : MonoBehaviour
{

    public GameObject pointDisplay;
    public static int pointValue = 0;
    public int internalPoint;

    private void Update()
    {
        internalPoint = pointValue;
        pointDisplay.GetComponent<TextMeshProUGUI>().text = "" + pointValue;
    }
}