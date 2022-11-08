using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun; 
    public GameObject fakeHandgun;
    public AudioSource handgunPickupSound;

    private void OnTriggerEnter(Collider other) // Cube의 콜라이더에 닿을 시 발동되는 메서드
    {
        realHandgun.SetActive(true); // 실제 사용되는 총 활성화
        fakeHandgun.SetActive(false); // 가짜 총 비활성화
        handgunPickupSound.Play(); // 총을 들어올릴 시에 들리는 소리 활성화
    }

}
