using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalAmmo : MonoBehaviour
{
    public static int gunAmmo;
    public GameObject ammoDisplay;

    void Update()
    {
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "" + gunAmmo;
    }
}
