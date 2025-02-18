using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera_;
    private bool isJumping = false;
    private float jumpHeight = 0.5f; // 점프 높이
    private float jumpDuration = 0.5f; // 점프 지속 시간
    private float jumpTimer = 0f;
    private float originalScale; // 기본 크기 저장

    protected override void Start()
    {
        base.Start();
        camera_ = Camera.main;
        originalScale = transform.localScale.y; // 기본 크기 저장
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized; // 이동 방향

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
        base.FixedUpdate(); // 기본 이동 처리

        if (isJumping)
        {
            jumpTimer += Time.fixedDeltaTime;
            float jumpProgress = jumpTimer / jumpDuration;

            if (jumpProgress < 0.5f)
            {
                // 상승 (크기 키우기)
                transform.localScale = new Vector3(originalScale * 1.2f, originalScale * 1.2f, 1f);
            }
            else if (jumpProgress < 1f)
            {
                // 하강 (원래 크기로 돌아오기)
                transform.localScale = new Vector3(originalScale, originalScale, 1f);
            }
            else
            {
                // 점프 종료
                isJumping = false;
                transform.localScale = new Vector3(originalScale, originalScale, 1f); // 크기 복구
                Debug.Log("Jump Ended!");
            }
        }
    }
}
