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

    private bool isScoped = false; // ������ �������� �Ǵ� bool ���� false��

    private void Start()
    {
        rifleRenderer = GetComponent<MeshRenderer>(); // ������ MeshRenderer ������Ʈ�� �Ҵ�
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire2")) // ���콺 ���� Ű�� ������ (InputManager�� �Ҵ�� �Է°�)
        {
            isScoped = !isScoped; // ����Ʈ ���� false�� �����Ǿ��� bool ���� true�� ���� ������ ����
            animator.SetBool("IsScoped", isScoped); // �Ķ������ IsScoped�� true�� ����Ǿ������� ����

            if(isScoped) // ���� bool ���� �⺻ �������̶��
            {
                StartCoroutine(OnScoped()); // OnScoped �޼��� �ڷ�ƾ �ߵ�
            }
            else
            {
                OnUnScoped(); // bool ���� �⺻ ���� �ƴ϶�� �ߵ��Ǵ� �޼��� 
            }
        }
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false); // ������ �������� �̹��� ��Ȱ��ȭ
        rifleRenderer.enabled = true; // �����ÿ� �Ҵ�� �޽��������� Ȱ��ȭ
                                      // ī�޶� �۵����� ���� �� ������ �޽��������� ��Ȱ��ȭ�� �����̱� ������
                                      // ���� Ȱ��ȭ �����־�� ��
        // weaponCamera.SetActive(true);

        playerCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f); // 0.15�� �Ŀ�

        scopeOverlay.SetActive(true); // ������ �������� �̹��� UI Ȱ��ȭ
        rifleRenderer.enabled = false; // �����÷����� ��Ȱ��ȭ
        // weaponCamera.SetActive(false);
        normalFOV = playerCamera.fieldOfView; 
        playerCamera.fieldOfView = scopedFOV;
    }
}
