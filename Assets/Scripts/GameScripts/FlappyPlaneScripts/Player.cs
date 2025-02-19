using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody2D;
    GameManager gameManager;

    public float flapForce = 6f; // 점프의 힘
    public float forwardSpeed = 3f; // 앞으로 나가는 힘
    public bool isDead = false; // 사망여부
    float deathCooldown = 0f;   // 뒤늦게 죽기

    bool isFlap = false; // 점프 여부
    public bool godMode = false;    // 싱글톤으로 Awke를 사용하기에 Start에 추가가
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        // GetComponentInChildren 하위 오브젝트에 있는 검사 후 반환
        animator = GetComponentInChildren<Animator>();
        // GetComponet 지정된 메소드가 있다면 반환
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");
        if (_rigidbody2D == null)
            Debug.LogError("Not Founded Rigidboby2D");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if(deathCooldown <= 0)
            {
                // 게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                // deltaTime은 이전 프로임과 현재 프레임 사이의 시간을 반환환
                deathCooldown -=Time.deltaTime;
            }
        }
        else
        {   // 마우스 0 : 좌, 1: 우, 2 : 휠, 3 : 앞, 4 뒤
            // 스마트폰 터치 = 마우스 0
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    // 물리를 처리
    void FixedUpdate()
    {
        if(isDead) return;
        // velocity = 가속도
        Vector3 velocity = _rigidbody2D.velocity;
        velocity.x = forwardSpeed;
        if(isFlap)
        { 
            velocity.y += flapForce;
            isFlap = false;
        }
        // Vector3는 구조체로 복사하여 받아왔기 때문에 다시 선언
        _rigidbody2D.velocity = velocity;

        // Clamp(특정한 값, min,max)는 값의 제한을 두는 메소드
        float angle = Math.Clamp((_rigidbody2D.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode)return;
        if(isDead) return;
        isDead = true;  
        deathCooldown = 1f;
        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
