using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject theGun; // �� ������Ʈ
    public GameObject muzzleFlash; // �÷��� ������Ʈ
    public AudioSource gunFire; // �� �� �� ����Ǵ� ȿ����
    public bool isFiring = false; // ���� �߻���� �ʵ��� false������ �ʱ�ȭ
    public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 3;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Fire1 Ű�� ������
        {
            if(GlobalAmmo.gunAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {
                if (isFiring == false)
                {
                    StartCoroutine(FiringHandgun()); // �ѿ� �� �� �ߵ��Ǵ� �޼���
                }
            } 
        }
    }

    IEnumerator FiringHandgun()
    {
        RaycastHit theShot;
        isFiring = true; // ���� �߻�� �� �ֵ��� bool���� true�� �ʱ�ȭ
        GlobalAmmo.gunAmmo -= 1; // �߻� �� �پ��� źȯ��
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))
        {
            // Ray�� ���濡 ��Ƽ� �ԷµǴ� �Ÿ� ������ targetDistance ������ �Ҵ��
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        theGun.GetComponent<Animator>().Play("GunFire"); // ���� Animator ������Ʈ�� GunFire �̸��� �ִϸ��̼� �ߵ�
        muzzleFlash.SetActive(true); // ���� �߻�� �� ���̴� �� ������Ʈ Ȱ��ȭ
        gunFire.Play(); // �Ѿ��� �߻�� �� ����Ǵ� ȿ����

        yield return new WaitForSeconds(0.03f); // 0.03�� ���� ���
        muzzleFlash.SetActive(false); // �� ������Ʈ ��Ȱ��ȭ
        yield return new WaitForSeconds(0.25f); // 0.25�� ���� ���
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false; // ���� �߻���� �ʵ��� bool ���� false �Ҵ�
    }
}
