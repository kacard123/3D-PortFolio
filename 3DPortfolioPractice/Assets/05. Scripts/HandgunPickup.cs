using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun; 
    public GameObject fakeHandgun;
    public AudioSource handgunPickupSound;

    private void OnTriggerEnter(Collider other) // Cube�� �ݶ��̴��� ���� �� �ߵ��Ǵ� �޼���
    {
        realHandgun.SetActive(true); // ���� ���Ǵ� �� Ȱ��ȭ
        fakeHandgun.SetActive(false); // ��¥ �� ��Ȱ��ȭ
        handgunPickupSound.Play(); // ���� ���ø� �ÿ� �鸮�� �Ҹ� Ȱ��ȭ
    }

}
