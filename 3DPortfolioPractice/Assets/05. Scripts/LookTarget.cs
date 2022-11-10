
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    public Transform target; // 타깃의 위치

    void Update()
    {
        // 스크립트가 할당된 군인 오브젝트의 시선이 변수 taarget에 할당된 오브젝트를 향하게 한다.
        transform.LookAt(target); // 타겟을 향해 오브젝트 위치 회전값이 변함
    }

}
