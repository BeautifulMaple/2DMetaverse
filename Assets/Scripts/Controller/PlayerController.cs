using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera_;
    private bool isJumping = false;
    private float jumpHeight = 0.5f; // ���� ����
    private float jumpDuration = 0.5f; // ���� ���� �ð�
    private float jumpTimer = 0f;
    private float originalScale; // �⺻ ũ�� ����

    protected override void Start()
    {
        base.Start();
        camera_ = Camera.main;
        originalScale = transform.localScale.y; // �⺻ ũ�� ����
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized; // �̵� ����

        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            Debug.Log("Jump Started!");
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate(); // �⺻ �̵� ó��

        if (isJumping)
        {
            jumpTimer += Time.fixedDeltaTime;
            float jumpProgress = jumpTimer / jumpDuration;

            if (jumpProgress < 0.5f)
            {
                // ��� (ũ�� Ű���)
                transform.localScale = new Vector3(originalScale * 1.2f, originalScale * 1.2f, 1f);
            }
            else if (jumpProgress < 1f)
            {
                // �ϰ� (���� ũ��� ���ƿ���)
                transform.localScale = new Vector3(originalScale, originalScale, 1f);
            }
            else
            {
                // ���� ����
                isJumping = false;
                transform.localScale = new Vector3(originalScale, originalScale, 1f); // ũ�� ����
                Debug.Log("Jump Ended!");
            }
        }
    }
}
