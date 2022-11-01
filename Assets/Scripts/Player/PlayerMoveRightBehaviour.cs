using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRightBehaviour : IPlayerBehaviour
{
    private Player _player;

    public PlayerMoveRightBehaviour(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    void IPlayerBehaviour.Update()
    {
        _player.MoveRight();
    }
}
