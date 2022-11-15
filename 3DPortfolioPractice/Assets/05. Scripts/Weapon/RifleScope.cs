using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    // public GameObject weaponCamera;
    public Camera playerCamera;

    [SerializeField]private MeshRenderer rifleRenderer;
    public float scopedFOV = 15f;
    private float normalFOV;

    private bool isScoped = false; // 초점이 스코프가 되는 bool 값을 false로

    private void Start()
    {
        rifleRenderer = GetComponent<MeshRenderer>(); // 변수에 MeshRenderer 컴포넌트를 할당
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire2")) // 마우스 왼쪽 키를 누르면 (InputManager에 할당된 입력값)
        {
            isScoped = !isScoped; // 디폴트 값이 false로 설정되었던 bool 값이 true의 값과 같도록 설정
            animator.SetBool("IsScoped", isScoped); // 파라미터의 IsScoped을 true로 재생되어지도록 만듦

            if(isScoped) // 만약 bool 값이 기본 설정값이라면
            {
                StartCoroutine(OnScoped()); // OnScoped 메서드 코루틴 발동
            }
            else
            {
                OnUnScoped(); // bool 값이 기본 값이 아니라면 발동되는 메서드 
            }
        }
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false); // 스코프 오버레이 이미지 비활성화
        rifleRenderer.enabled = true; // 라이플에 할당된 메쉬렌더러를 활성화
                                      // 카메라가 작동되지 않을 때 라이플 메쉬센더러도 비활성화된 상태이기 때문에
                                      // 같이 활성화 시켜주어야 함
        // weaponCamera.SetActive(true);

        playerCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f); // 0.15초 후에

        scopeOverlay.SetActive(true); // 스코프 오버레이 이미지 UI 활성화
        rifleRenderer.enabled = false; // 라이플렌더러 비활성화
        // weaponCamera.SetActive(false);
        normalFOV = playerCamera.fieldOfView; 
        playerCamera.fieldOfView = scopedFOV;
    }
}
