using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiflePickup : MonoBehaviour
{
    public GameObject realRifle;
    public GameObject fakeRifle;
    public AudioSource riflePickupSound;
    public GameObject pickUpDisplay;

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        realRifle.SetActive(true); // ���� ���Ǵ� �� Ȱ��ȭ
        fakeRifle.SetActive(false); // ��¥ �� ��Ȱ��ȭ
        riflePickupSound.Play(); // ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false); // �ؽ�Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "Rifle"; // �ؽ�Ʈ �޽����� ������Ʈ�� ������ "CLIP OF BULLETS" ��Ÿ������ ����
        pickUpDisplay.SetActive(true); // �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
    }
}