using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLeftBehaviour : IPlayerBehaviour
{
    private Player _player;

    public PlayerMoveLeftBehaviour(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update()
    {
        _player.MoveLeft();
    }
}
