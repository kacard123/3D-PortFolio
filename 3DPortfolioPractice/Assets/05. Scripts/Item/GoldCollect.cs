using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCollect : MonoBehaviour
{
    public GameObject gold;
    public AudioSource collectSound;
    public GameObject pickUpDisplay;

    private void OnTriggerEnter(Collider other) // Cube의 콜라이더에 닿을 시 발동되는 메서드
    {
        GlobalPoint.pointValue += 500;
        gold.SetActive(false); // 가짜 총 비활성화
        collectSound.Play(); // 총을 들어올릴 시에 들리는 소리 활성화
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false); // 텍스트 게임오브젝트 비활성화
        pickUpDisplay.GetComponent<TextMeshProUGUI>().text = "GOLD"; // 텍스트 메쉬프로 컴포넌트를 가져와 "CLIP OF BULLETS" 나타내도록 설정
        pickUpDisplay.SetActive(true); // 텍스트 게임 오브젝트 활성화
    }
}
