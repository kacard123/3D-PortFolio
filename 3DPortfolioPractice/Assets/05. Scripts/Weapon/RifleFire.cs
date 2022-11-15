using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : MonoBehaviour
{
    public GameObject theGun; // �� ������Ʈ
    public GameObject muzzleFlash; // �÷��� ������Ʈ
    public AudioSource rifleFire; // �� �� �� ����Ǵ� ȿ����
    public bool isFiring = false; // ���� �߻���� �ʵ��� false������ �ʱ�ȭ
    public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 6;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 Ű�� ������
        {
            if (GlobalRifleAmmo.rifleAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {
                if (isFiring == false)
                {
                    StartCoroutine(FiringRifle()); // �ѿ� �� �� �ߵ��Ǵ� �޼���
                }
            }
        }
    }

    IEnumerator FiringRifle()
    {
        RaycastHit theShot;
        isFiring = true; // ���� �߻�� �� �ֵ��� bool���� true�� �ʱ�ȭ
        GlobalRifleAmmo.rifleAmmo -= 2; // �߻� �� �پ��� źȯ��
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))
        {
            // Ray�� ���濡 ��Ƽ� �ԷµǴ� �Ÿ� ������ targetDistance ������ �Ҵ��
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        theGun.GetComponent<Animator>().Play("RifleFire"); // ���� Animator ������Ʈ�� GunFire �̸��� �ִϸ��̼� �ߵ�
        muzzleFlash.SetActive(true); // ���� �߻�� �� ���̴� �� ������Ʈ Ȱ��ȭ
        rifleFire.Play(); // �Ѿ��� �߻�� �� ����Ǵ� ȿ����

        yield return new WaitForSeconds(0.05f); // 0.05�� ���� ���
        muzzleFlash.SetActive(false); // �� ������Ʈ ��Ȱ��ȭ
        yield return new WaitForSeconds(0.4f); // 0.25�� ���� ���
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false; // ���� �߻���� �ʵ��� bool ���� false �Ҵ�
    }
}
