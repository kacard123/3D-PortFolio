using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun; 
    public GameObject fakeHandgun;
    public AudioSource handgunPickupSound;
    public GameObject pickUpDisplay;

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        realHandgun.SetActive(true); // ���� ���Ǵ� �� Ȱ��ȭ
        fakeHandgun.SetActive(false); // ��¥ �� ��Ȱ��ȭ
        handgunPickupSound.Play(); // ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false); // �ؽ�Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "HANDGUN"; // �ؽ�Ʈ �޽����� ������Ʈ�� ������ "CLIP OF BULLETS" ��Ÿ������ ����
        pickUpDisplay.SetActive(true); // �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
    }

}
