using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("HP")] protected int _enemyHp;
    [SerializeField, Header("UŒ‚—Í")] protected int _enemyAttackPower;
    [SerializeField, Header("ˆÚ“®‘¬“x")] int _enemyMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDamage(int damage)
    {
        _enemyHp -= damage;
        if(_enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
