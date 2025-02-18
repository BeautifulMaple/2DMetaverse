using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform targetTrans;
    float offsetX;
    float offsetY;

    private void Start()
    {
        if (targetTrans == null) return;  // ����� ������ �������� ����
        offsetX = transform.position.x - targetTrans.position.x; // �ʱ� ������ ����
        offsetY = transform.position.y - targetTrans.position.y; // �ʱ� ������ ����

    }
    private void Update()
    {
        if (targetTrans == null) return;

        Vector3 pos = transform.position;
        pos.x = targetTrans.position.x + offsetX;
        pos.y = targetTrans.position.y + offsetY;
        transform.position = pos;
    }

}
