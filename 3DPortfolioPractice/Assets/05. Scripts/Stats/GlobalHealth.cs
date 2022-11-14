using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{

    [SerializeField]
    public Image healthBar;

    private float healthValue = 100; // �÷��̾��� �⺻ ������ ��ġ
    public static float internalHealth; // �÷��̾� ���� ������ ��ġ
    float imsi;

    private void Start()
    {
        healthBar = GetComponent<Image>();

        internalHealth = healthValue;
    }

    private void Update()
    {
        HandleHp();

        if (internalHealth != null)
        {
            healthBar.fillAmount = internalHealth / healthValue;
        }

        if (healthBar.fillAmount <= 0)
        {
            SceneManager.LoadScene(1);
        }

        // healthDisplay.GetComponent<TextMeshProUGUI>().text = "" + healthValue + "%";
    }

    private void HandleHp()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, imsi, Time.deltaTime * 10); // Mathf.Lerp(float A, float B, float t) -> A�� B ������ t��ŭ�� ���� ��ȯ
    }
}
