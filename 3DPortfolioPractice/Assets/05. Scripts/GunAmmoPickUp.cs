
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmoPickUp : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;

    private void OnTriggerEnter(Collider other) // Cube의 콜라이더에 닿을 시 발동되는 메서드
    {
        fakeAmmoClip.SetActive(false); // 가짜 탄약 팩 비활성화
        ammoPickupSound.Play(); // 탄약 팩을 들어올릴 시에 들리는 소리 활성화
        GlobalAmmo.gunAmmo += 10; // 탄약 팩 안에 든 총알 수
    }
}
