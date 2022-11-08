using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor; // �� ������Ʈ ����
    public AudioSource doorFX; // �� �ִϸ��̼� �۵��� �鸮�� ������ҽ�

    private void OnTriggerEnter(Collider other)
    {
        theDoor.GetComponent<Animator>().Play("DoorOpen"); // ������Ʈ�� ���� �Ҵ�� �ִϸ����� ������Ʈ�� ���� �������� �ִϸ��̼� �ߵ� 
        doorFX.Play(); // �� �ִϸ��̼� ����� ����� �÷���
        this.GetComponent<BoxCollider>().enabled = false; // �ݶ��̴� ��Ȱ��ȭ
        StartCoroutine(CloseDoor()); // �ڷ�ƾ �޼��� �ߵ�
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5f); // 5�ʰ��� ���ð� ��
        doorFX.Play();// ���� ������ ȿ���� �ߵ�
        theDoor.GetComponent<Animator>().Play("DoorClose"); // �ִϸ����� ������Ʈ�� ���� �� ������ �ִϸ��̼� �ߵ�
        this.GetComponent<BoxCollider>().enabled = true; // �ݶ��̴� Ȱ��ȭ
    }
}
