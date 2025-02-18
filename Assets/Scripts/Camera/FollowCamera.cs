using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform targetTrans; // 따라갈 대상
    public Vector2 minLimit; // 카메라 이동 최소 좌표 (왼쪽 아래)
    public Vector2 maxLimit; // 카메라 이동 최대 좌표 (오른쪽 위)

    private float offsetX;
    private float offsetY;

    private void Start()
    {
        if (targetTrans == null) return;  // 대상이 없으면 실행하지 않음

        // 초기 오프셋 저장
        offsetX = transform.position.x - targetTrans.position.x;
        offsetY = transform.position.y - targetTrans.position.y;
    }

    private void LateUpdate()
    {
        if (targetTrans == null) return;

        // 목표 위치 계산
        float targetX = targetTrans.position.x + offsetX;
        float targetY = targetTrans.position.y + offsetY;

        // 카메라 이동을 최소/최대 영역 내로 제한
        float clampedX = Mathf.Clamp(targetX, minLimit.x, maxLimit.x);
        float clampedY = Mathf.Clamp(targetY, minLimit.y, maxLimit.y);

        // 최종 위치 적용
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
