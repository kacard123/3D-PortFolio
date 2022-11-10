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

    private void Update()
    {
        RaycastHit Hit; // �浹 ������ ������ RaycastHit�� ����
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag; // hitTag�� ray�� �浹���� �� ���� ��ġ�� ����
            lookingAtplayer = true; 
        }
        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(Enemyfire());
        }
        if(hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Idle"); // Sldier�� �ִϸ��̼� "Idle" ���
            lookingAtplayer = false;
        }

        IEnumerator Enemyfire()
        {
            isFiring = true;
            theSoldier.GetComponent<Animator>().Play("FiringRifle", -1, 0);
            fireSound.Play();
            lookingAtplayer  = true;
            GlobalHealth.healthValue -= 3; // ���� �� �ѹ� ������ �÷��̾��� ������ ��ġ�� 3�� ���δ�
            genHurt = Random.Range(0, 3);
            hurtSound[genHurt].Play();

            yield return new WaitForSeconds(fireRate);
            isFiring = false;
        }
    }
}
