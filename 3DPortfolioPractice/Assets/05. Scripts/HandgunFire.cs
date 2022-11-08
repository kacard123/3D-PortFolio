using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject theGun; // 총 오브젝트
    public GameObject muzzleFlash; // 플레시 오브젝트
    public AudioSource gunFire; // 총 쏠 때 재생되는 효과음
    public bool isFiring = false; // 총이 발사되지 않도록 false값으로 초기화
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Fire1 키를 누르면
        {
            if(isFiring == false)
            {
                StartCoroutine(FiringHandgun()); // 총올 쏠 때 발동되는 메서드
            }
        }
    }

    IEnumerator FiringHandgun()
    {
        isFiring = true; // 총이 발사될 수 있도록 bool값을 true로 초기화
        theGun.GetComponent<Animator>().Play("GunFire"); // 총의 Animator 컴포넌트의 GunFire 이름의 애니메이션 발동
        muzzleFlash.SetActive(true); // 총이 발사될 때 보이는 빛 오브젝트 활성화
        gunFire.Play(); // 총알이 발사될 때 재생되는 효과음
        yield return new WaitForSeconds(0.03f); // 0.03초 동안 대기
        muzzleFlash.SetActive(false); // 빛 오브젝트 비활성화
        yield return new WaitForSeconds(0.25f); // 0.25초 동안 대기
        isFiring = false; // 총이 발사되지 않도록 bool 값에 false 할당
    }
}
