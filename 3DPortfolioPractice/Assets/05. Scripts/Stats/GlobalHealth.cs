using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public static int healthValue; // 플레이어의 기본 에너지 수치
    public int internalHealth; // 플레이어 현재 에너지 수치

    private void Start()
    {
        healthValue = 100;
    }

    private void Update()
    {
        if(healthValue <= 0)
        {
            SceneManager.LoadScene(1);
        }
        internalHealth = healthValue;
        healthDisplay.GetComponent<TextMeshProUGUI>().text = "" + healthValue + "%";
    }
}
