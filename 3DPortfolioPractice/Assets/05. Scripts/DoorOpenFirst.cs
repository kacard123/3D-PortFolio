using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject theDoor; // 문 오브젝트 변수
    public AudioSource doorFX; // 문 애니메이션 작동시 들리는 오디오소스

    private void OnTriggerEnter(Collider other)
    {
        theDoor.GetComponent<Animator>().Play("DoorOpen"); // 오브젝트인 문에 할당된 애니메이터 컴포넌트를 통해 문열리는 애니메이션 발동 
        doorFX.Play(); // 문 애니메이션 재생시 오디오 플레이
        this.GetComponent<BoxCollider>().enabled = false; // 콜라이더 비활성화
        StartCoroutine(CloseDoor()); // 코루틴 메서드 발동
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5f); // 5초간의 대기시간 후
        doorFX.Play();// 문이 닫히는 효과음 발동
        theDoor.GetComponent<Animator>().Play("DoorClose"); // 애니메이터 컴포넌트를 통해 문 닫히는 애니메이션 발동
        this.GetComponent<BoxCollider>().enabled = true; // 콜라이더 활성화
    }
}
