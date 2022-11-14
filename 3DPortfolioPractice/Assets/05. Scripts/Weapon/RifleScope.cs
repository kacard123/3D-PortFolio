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

    private bool isScoped = false; // ������ �������� �Ǵ� bool ���� false��

    private void Update()
    {
        if(Input.GetButtonDown("Fire2")) // ���콺 ���� Ű�� ������ (InputManager�� �Ҵ�� �Է°�)
        {
            isScoped = !isScoped; // ����Ʈ ���� false�� �����Ǿ��� bool ���� true�� ���� ������ ����
            animator.SetBool("IsScoped", isScoped); // �Ķ������ IsScoped�� true�� ����Ǿ������� ����

            if(isScoped) // ���� bool ���� �⺻ �������̶��            
                StartCoroutine(OnScoped()); // OnScoped �޼��� �ڷ�ƾ �ߵ�
            else
                OnUnScoped(); // bool ���� �⺻ ���� �ƴ϶�� �ߵ��Ǵ� �޼��� 
        }
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        playerCamera.fieldOfView = normalFOV;
        Debug.Log("���ֿ�");
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
