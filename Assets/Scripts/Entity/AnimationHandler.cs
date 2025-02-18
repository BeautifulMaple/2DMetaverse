using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //readonly 생성자에서만 값을 할당 가능
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        // 이동 벡터의 크기가 0.5 이상이면 이동 중으로 판단
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }
    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }

    public void InvincibilityEnd()  //무적 해제 후 피격 애니메이션 종료
    {
        animator.SetBool(IsDamage, false);
    }
}
