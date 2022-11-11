using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public string hitTag; // Soldier������Ʈ�� �ܳ��� ������Ʈ�� �±װ�
    public bool lookingAtplayer = false; 
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false; // Soldier�� �� �߻�
    public float fireRate = 1f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    private void Update()
    {
        RaycastHit Hit; // �浹 ������ ������ RaycastHit�� ����
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag; // hitTag�� ray�� �浹���� �� ���� ��ġ�� ����
            lookingAtplayer = true; 
        }
        if (hitTag == "Player" && isFiring == false) // �浹 �±װ� Player�̰� isFiring�� bool ���� falsef���
        {
            StartCoroutine(Enemyfire()); // �ڷ�ƾ �ߵ�
        }
        if(hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Idle"); // Sldier�� �ִϸ��̼� "Idle" ���
            lookingAtplayer = false;
        }

        IEnumerator Enemyfire() // �ڷ�ƾ �޼���
        {
            isFiring = true; // bool ���� true
            theSoldier.GetComponent<Animator>().Play("FiringRifle", -1, 0); 
            fireSound.Play(); // ���� �� �� �鸮�� ���� ���
            lookingAtplayer  = true; // �÷��̾ �������� �� bool ���� true�� ����
            GlobalHealth.healthValue -= 3; // ���� �� �ѹ� ������ �÷��̾��� ������ ��ġ�� 3�� ���δ�
            hurtFlash.SetActive(true); // �ǰݽ� �ߵ��Ǵ� UI Ȱ��ȭ
            yield return new WaitForSeconds(0.2f); // 0.2�� �Ŀ�
            hurtFlash.SetActive(false); // �ǰݽ� �ߵ��Ǵ� UI�� ��Ȱ��ȭ
            genHurt = Random.Range(0, 3); // ���� ���� ����, �� ���� ���Ե��� �ʴ´ٴ� �����Ͽ� ���� ���� getHurt��� ������ �Ҵ�
            hurtSound[genHurt].Play(); // �ѿ� �¾��� �� ����Ǵ� ����
            yield return new WaitForSeconds(fireRate); // �Ѿ��� �߻�Ǵ� ���� �Ŀ�
            isFiring = false; // isFiring�� bool �� false
        }
    }
}
