using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Currency;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private TouchControll[] _touchControlls;
    [SerializeField] private Bank _bank;

    [SerializeField] private Player _playerPrefab;

    private void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        var player = Instantiate(_playerPrefab, transform.position, transform.rotation);

        player.Init(_bank);

        foreach (var touchControll in _touchControlls)
        {
            touchControll.Init(player);
        }
    }
}
