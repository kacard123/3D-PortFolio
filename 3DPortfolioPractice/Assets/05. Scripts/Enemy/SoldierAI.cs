using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public string hitTag; // Soldier오브젝트가 겨냥할 오브젝트의 태그값
    public bool lookingAtplayer = false; 
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false; // Soldier의 총 발사
    public float fireRate = 1f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    private void Update()
    {
        RaycastHit Hit; // 충돌 정보를 저장할 RaycastHit의 변수
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag; // hitTag에 ray가 충돌했을 때 얻은 위치값 저장
            lookingAtplayer = true; 
        }
        if (hitTag == "Player" && isFiring == false) // 충돌 태그가 Player이고 isFiring의 bool 값이 falsef라면
        {
            StartCoroutine(Enemyfire()); // 코루틴 발동
        }
        if(hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Idle"); // Sldier의 애니메이션 "Idle" 재생
            lookingAtplayer = false;
        }

        IEnumerator Enemyfire() // 코루틴 메서드
        {
            isFiring = true; // bool 값이 true
            theSoldier.GetComponent<Animator>().Play("FiringRifle", -1, 0); 
            fireSound.Play(); // 총을 쏠 때 들리는 사운드 재생
            lookingAtplayer  = true; // 플레이어를 향해있을 때 bool 값이 true로 변함
            GlobalHealth.healthValue -= 3; // 적의 총 한번 맞으면 플레이어의 에너지 수치가 3씩 깎인다
            hurtFlash.SetActive(true); // 피격시 발동되는 UI 활성화
            yield return new WaitForSeconds(0.2f); // 0.2초 후에
            hurtFlash.SetActive(false); // 피격시 발동되는 UI를 비활성화
            genHurt = Random.Range(0, 3); // 시작 값은 포함, 끝 값은 포함되지 않는다는 전제하에 랜덤 값을 getHurt라는 변수에 할당
            hurtSound[genHurt].Play(); // 총에 맞았을 때 재생되는 사운드
            yield return new WaitForSeconds(fireRate); // 총알이 발사되는 간격 후에
            isFiring = false; // isFiring의 bool 값 false
        }
    }
}
