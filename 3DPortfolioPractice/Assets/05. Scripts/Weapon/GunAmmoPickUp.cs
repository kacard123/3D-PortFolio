
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunAmmoPickUp : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay; // �ؽ�Ʈ ���� ���ӿ�����Ʈ ������ ����

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        fakeAmmoClip.SetActive(false); // ��¥ ź�� �� ��Ȱ��ȭ
        ammoPickupSound.Play(); // ź�� ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GlobalAmmo.gunAmmo += 10; // ź�� �� �ȿ� �� �Ѿ� ��
        pickUpDisplay.SetActive(false); // �ؽ�Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "CLIP OF BULLETS"; // �ؽ�Ʈ �޽����� ������Ʈ�� ������ "CLIP OF BULLETS" ��Ÿ������ ����
        pickUpDisplay.SetActive(true); // �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
    }
}
