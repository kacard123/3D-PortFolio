using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : MonoBehaviour
{
    public GameObject theGun; // 총 오브젝트
    public GameObject muzzleFlash; // 플레시 오브젝트
    public AudioSource rifleFire; // 총 쏠 때 재생되는 효과음
    public bool isFiring = false; // 총이 발사되지 않도록 false값으로 초기화
    public AudioSource emptySound;
    public float targetDistance;
    public int damageAmount = 6;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 키를 누르면
        {
            if (GlobalRifleAmmo.rifleAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {
                if (isFiring == false)
                {
                    StartCoroutine(FiringRifle()); // 총올 쏠 때 발동되는 메서드
                }
            }
        }
    }

    IEnumerator FiringRifle()
    {
        RaycastHit theShot;
        isFiring = true; // 총이 발사될 수 있도록 bool값을 true로 초기화
        GlobalRifleAmmo.rifleAmmo -= 2; // 발사 시 줄어드는 탄환수
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))
        {
            // Ray가 상대방에 닿아서 입력되는 거리 정보가 targetDistance 변수에 할당됨
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        theGun.GetComponent<Animator>().Play("RifleFire"); // 총의 Animator 컴포넌트의 GunFire 이름의 애니메이션 발동
        muzzleFlash.SetActive(true); // 총이 발사될 때 보이는 빛 오브젝트 활성화
        rifleFire.Play(); // 총알이 발사될 때 재생되는 효과음

        yield return new WaitForSeconds(0.05f); // 0.05초 동안 대기
        muzzleFlash.SetActive(false); // 빛 오브젝트 비활성화
        yield return new WaitForSeconds(0.4f); // 0.25초 동안 대기
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false; // 총이 발사되지 않도록 bool 값에 false 할당
    }
}
