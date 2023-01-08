using UnityEngine;
using Currency;
using Lifebar;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private TouchControll[] _touchControlls;
    [SerializeField] private Bank _bank;
    [SerializeField] private PlayerLifebar _palyerLifebar;

    [SerializeField] private Player _playerPrefab;

    private void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        var player = Instantiate(_playerPrefab, transform.position, transform.rotation);

        player.Init(_bank);

        player.GetComponent<PlayerBoosts>().Init(_palyerLifebar);

        foreach (var touchControll in _touchControlls)
        {
            touchControll.Init(player);
        }
    }
}
