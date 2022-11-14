using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera playerCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    private bool isScoped = false; // 초점이 스코프가 되는 bool 값을 false로

    private void Update()
    {
        if(Input.GetButtonDown("Fire2")) // 마우스 왼쪽 키를 누르면 (InputManager에 할당된 입력값)
        {
            isScoped = !isScoped; // 디폴트 값이 false로 설정되었던 bool 값이 true의 값과 같도록 설정
            animator.SetBool("IsScoped", isScoped); // 파라미터의 IsScoped을 true로 재생되어지도록 만듦

            if(isScoped) // 만약 bool 값이 기본 설정값이라면            
                StartCoroutine(OnScoped()); // OnScoped 메서드 코루틴 발동
            else
                OnUnScoped(); // bool 값이 기본 값이 아니라면 발동되는 메서드 
        }
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        playerCamera.fieldOfView = normalFOV;
        Debug.Log("임주영");
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = playerCamera.fieldOfView;
        playerCamera.fieldOfView = scopedFOV;
    }
}
