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
        // ������ ���̸� ����ȭ�� = 1�� 
        movementDirection = new Vector2(horizontal, vertical).normalized;
        /*
        Vector2 mousePosition = Input.mousePosition;    // ���콺 ȭ�� ��ǥ ��������
        Vector2 worlPos = camera_.ScreenToWorldPoint(mousePosition);    //���� ��ǥ�� ��ȯ
        // �÷��̾� ���콺 ��ġ ���ϱ�
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
