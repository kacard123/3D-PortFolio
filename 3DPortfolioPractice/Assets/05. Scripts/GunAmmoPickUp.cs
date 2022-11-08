
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmoPickUp : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        fakeAmmoClip.SetActive(false); // ��¥ ź�� �� ��Ȱ��ȭ
        ammoPickupSound.Play(); // ź�� ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
        GlobalAmmo.gunAmmo += 10; // ź�� �� �ȿ� �� �Ѿ� ��
    }
}
