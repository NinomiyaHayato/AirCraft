using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1State :IState
{
    Vector3 pos;
    PlayerController _player;
    public Attack1State(PlayerController playerController) { _player = playerController; }
    
    public void Enter()
    {
        throw new System.NotImplementedException();
    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }
    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
