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
        if (targetTrans == null) return;  // 대상이 없으면 실행하지 않음
        offsetX = transform.position.x - targetTrans.position.x; // 초기 오프셋 저장
        offsetY = transform.position.y - targetTrans.position.y; // 초기 오프셋 저장

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
