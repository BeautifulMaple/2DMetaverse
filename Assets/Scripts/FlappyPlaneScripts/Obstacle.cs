using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // public으로 선언 시 Inspector 창에서 설정할 수 있음음
    public float highPosY = 1f; // 위로 이동
    public float lowPosY = -1f;  // 아래로 이동

    // top과 buttom 사이의 공간
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        // localPosition = 부모 오브젝트 기준 포지션
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // 제일 마지막에 놓여진 오브젝트 뒤에 배치
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition;

        return placePosition;
    }
    // trigger를 벗어날 떄
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
            gameManager.AddScore(1);
    }
}
