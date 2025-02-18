using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera_;

    protected override void Start()
    {
        base.Start();
        camera_ = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // 벡터의 길이를 정규화함 = 1로 
        movementDirection = new Vector2(horizontal, vertical).normalized;
        /*
        Vector2 mousePosition = Input.mousePosition;    // 마우스 화면 좌표 가져오기
        Vector2 worlPos = camera_.ScreenToWorldPoint(mousePosition);    //월드 좌표로 전환
        // 플레이어 마우스 위치 구하기
        lookDirection = (worlPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }*/

        if(movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection;
        }
    }

}
