using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject theGun; // �� ������Ʈ
    public GameObject muzzleFlash; // �÷��� ������Ʈ
    public AudioSource gunFire; // �� �� �� ����Ǵ� ȿ����
    public bool isFiring = false; // ���� �߻���� �ʵ��� false������ �ʱ�ȭ
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Fire1 Ű�� ������
        {
            if(isFiring == false)
            {
                StartCoroutine(FiringHandgun()); // �ѿ� �� �� �ߵ��Ǵ� �޼���
            }
        }
    }

    IEnumerator FiringHandgun()
    {
        isFiring = true; // ���� �߻�� �� �ֵ��� bool���� true�� �ʱ�ȭ
        theGun.GetComponent<Animator>().Play("GunFire"); // ���� Animator ������Ʈ�� GunFire �̸��� �ִϸ��̼� �ߵ�
        muzzleFlash.SetActive(true); // ���� �߻�� �� ���̴� �� ������Ʈ Ȱ��ȭ
        gunFire.Play(); // �Ѿ��� �߻�� �� ����Ǵ� ȿ����
        yield return new WaitForSeconds(0.03f); // 0.03�� ���� ���
        muzzleFlash.SetActive(false); // �� ������Ʈ ��Ȱ��ȭ
        yield return new WaitForSeconds(0.25f); // 0.25�� ���� ���
        isFiring = false; // ���� �߻���� �ʵ��� bool ���� false �Ҵ�
    }
}
