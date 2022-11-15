using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalRifleAmmo : MonoBehaviour
{
    public static int rifleAmmo;
    public GameObject rifleammoDisplay;


    void Update()
    {
        rifleammoDisplay.GetComponent<TextMeshProUGUI>().text = "" + rifleAmmo;
    }
}