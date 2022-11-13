using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    // public GameObject healthDisplay;

    [SerializeField]
    Image healthBar;
    //[SerializeField]
    //private Slider hpbar;

    public float healthValue = 100f; // �÷��̾��� �⺻ ������ ��ġ
    public static float internalHealth; // �÷��̾� ���� ������ ��ġ

    private void Start()
    {
        healthBar = GetComponent<Image>();
        internalHealth = healthValue;
        // internalHealth = healthValue;
    }

    private void Update()
    {
        healthBar.fillAmount = internalHealth / healthValue;

        if (healthValue <= 0)
        {
            SceneManager.LoadScene(1);
        }

        // internalHealth = healthValue;
        // healthDisplay.GetComponent<TextMeshProUGUI>().text = "" + healthValue + "%";
    }

    //[SerializeField]
    //private Slider hpbar;

    //public static int maxHp; // �÷��̾��� �⺻ ������ ��ġ
    //public int curHp; // �÷��̾� ���� ������ ��ġ

    ////private static float maxHp = 100;
    ////private float curHp= 100;
    //float imsi;

    //void Start()
    //{
    //    maxHp = 100;
    //    curHp = 100; 
    //    hpbar.value = curHp / maxHp;
    //}

    //private void Update()
    //{
    //    HandleHp();

    //    if (maxHp <= 0)
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //    curHp = maxHp;
    //}

    //private void HandleHp()
    //{
    //    hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 10); // Mathf.Lerp(float A, float B, float t) -> A�� B ������ t��ŭ�� ���� ��ȯ
    //}
}
