using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform targetTrans; // ���� ���
    public Vector2 minLimit; // ī�޶� �̵� �ּ� ��ǥ (���� �Ʒ�)
    public Vector2 maxLimit; // ī�޶� �̵� �ִ� ��ǥ (������ ��)

    private float offsetX;
    private float offsetY;

    private void Start()
    {
        if (targetTrans == null) return;  // ����� ������ �������� ����

        // �ʱ� ������ ����
        offsetX = transform.position.x - targetTrans.position.x;
        offsetY = transform.position.y - targetTrans.position.y;
    }

    private void LateUpdate()
    {
        if (targetTrans == null) return;

        // ��ǥ ��ġ ���
        float targetX = targetTrans.position.x + offsetX;
        float targetY = targetTrans.position.y + offsetY;

        // ī�޶� �̵��� �ּ�/�ִ� ���� ���� ����
        float clampedX = Mathf.Clamp(targetX, minLimit.x, maxLimit.x);
        float clampedY = Mathf.Clamp(targetY, minLimit.y, maxLimit.y);

        // ���� ��ġ ����
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
