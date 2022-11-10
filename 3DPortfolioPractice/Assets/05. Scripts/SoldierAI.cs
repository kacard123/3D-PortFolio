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

    private void Update()
    {
        RaycastHit Hit; // 충돌 정보를 저장할 RaycastHit의 변수
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag; // hitTag에 ray가 충돌했을 때 얻은 위치값 저장
            lookingAtplayer = true; 
        }
        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(Enemyfire());
        }
        if(hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Idle"); // Sldier의 애니메이션 "Idle" 재생
            lookingAtplayer = false;
        }

        IEnumerator Enemyfire()
        {
            isFiring = true;
            theSoldier.GetComponent<Animator>().Play("FiringRifle", -1, 0);
            fireSound.Play();
            lookingAtplayer  = true;
            GlobalHealth.healthValue -= 3; // 적의 총 한번 맞으면 플레이어의 에너지 수치가 3씩 깎인다
            genHurt = Random.Range(0, 3);
            hurtSound[genHurt].Play();

            yield return new WaitForSeconds(fireRate);
            isFiring = false;
        }
    }
}
