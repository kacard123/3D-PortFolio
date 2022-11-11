
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunAmmoPickUp : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay; // 텍스트 관련 게임오브젝트 변수명 선언

    private void OnTriggerEnter(Collider other) // Cube의 콜라이더에 닿을 시 발동되는 메서드
    {
        fakeAmmoClip.SetActive(false); // 가짜 탄약 팩 비활성화
        ammoPickupSound.Play(); // 탄약 팩을 들어올릴 시에 들리는 소리 활성화
        GlobalAmmo.gunAmmo += 10; // 탄약 팩 안에 든 총알 수
        pickUpDisplay.SetActive(false); // 텍스트 게임오브젝트 비활성화
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "CLIP OF BULLETS"; // 텍스트 메쉬프로 컴포넌트를 가져와 "CLIP OF BULLETS" 나타내도록 설정
        pickUpDisplay.SetActive(true); // 텍스트 게임 오브젝트 활성화
    }
}
