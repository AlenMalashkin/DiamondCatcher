using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayBehaviour : IPlayerBehaviour
{
    private Player _player;

    public PlayerStayBehaviour(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Stop();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
