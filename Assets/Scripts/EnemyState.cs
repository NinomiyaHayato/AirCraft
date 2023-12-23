using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

    public EnemyAttackState _enemyAttackPattern = EnemyAttackState.Attack1;

    Attack1State _attack1;

    public EnemyAttackState EnemyAttackPattern
    {
        get => _enemyAttackPattern;

        set
        {
            _enemyAttackPattern = value;
            switch (_enemyAttackPattern)
            {
                case EnemyAttackState.Attack1:
                    _attack1.Enter();
                    break;
                case EnemyAttackState.Attack2:
                    break;
                case EnemyAttackState.Attack3:
                    break;
            }
        }
    }
    private void Start()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        _attack1 = new Attack1State(player);
    }

    private void Update()
    {
        switch (_enemyAttackPattern)
        {
            case EnemyAttackState.Attack1:
                _attack1.Update();
                break;
            case EnemyAttackState.Attack2:
                break;
            case EnemyAttackState.Attack3:
                break;
        }
    }

    public void StateChange(EnemyAttackState enemyAttackState)
    {
        EnemyAttackPattern = enemyAttackState;
    }
}

public enum EnemyAttackState
{
    Attack1,
    Attack2,
    Attack3
}
