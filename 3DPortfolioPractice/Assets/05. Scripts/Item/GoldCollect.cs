using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCollect : MonoBehaviour
{
    public GameObject gold;
    public AudioSource collectSound;
    public GameObject pickUpDisplay;

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        GlobalPoint.pointValue += 500;
        gold.SetActive(false); // ��¥ �� ��Ȱ��ȭ
        collectSound.Play(); // ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false); // �ؽ�Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "GOLD"; // �ؽ�Ʈ �޽����� ������Ʈ�� ������ "CLIP OF BULLETS" ��Ÿ������ ����
        pickUpDisplay.SetActive(true); // �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
    }
}
