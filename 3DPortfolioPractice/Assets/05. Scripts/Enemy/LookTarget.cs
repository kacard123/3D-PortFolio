
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    public Transform target; // Ÿ���� ��ġ

    void Update()
    {
        // ��ũ��Ʈ�� �Ҵ�� ���� ������Ʈ�� �ü��� ���� taarget�� �Ҵ�� ������Ʈ�� ���ϰ� �Ѵ�.
        transform.LookAt(target); // Ÿ���� ���� ������Ʈ ��ġ ȸ������ ����
    }

}
