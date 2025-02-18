using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;
        // 카메라와 플레이어 사이의 거리를 저장
        offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            return;
        // transform.position 바로 변동이 가능한 값이 아니다.
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;

    }
}
