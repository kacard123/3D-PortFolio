using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RifleAmmoPickUp : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay; // �ؽ�Ʈ ���� ���ӿ�����Ʈ ������ ����

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        fakeAmmoClip.SetActive(false); // ��¥ ź�� �� ��Ȱ��ȭ
        ammoPickupSound.Play(); // ź�� ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GlobalRifleAmmo.rifleAmmo += 30; // ź�� �� �ȿ� �� �Ѿ� ��
        gameObject.GetComponent<GlobalAmmo>().enabled = false;
        pickUpDisplay.SetActive(false); // �ؽ�Ʈ ���ӿ�����Ʈ ��Ȱ��ȭ
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "CLIP OF BULLETS"; // �ؽ�Ʈ �޽����� ������Ʈ�� ������ "CLIP OF BULLETS" ��Ÿ������ ����
        pickUpDisplay.SetActive(true); // �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
    }
}