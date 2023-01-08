using System.Collections.Generic;
using UnityEngine;
using System;
using Lifebar;

public class PlayerBoosts : MonoBehaviour
{
    [SerializeField] private float _boostDuration;

    private PlayerLifebar _playerLifebar;
    private Dictionary<string, Action> _playerBoosts;
    private Timer.Timer _timer;

    private void Awake()
    {
        _playerBoosts = new Dictionary<string, Action>();
        _playerBoosts.Add("SizeBoost", SizeBoost);
        _playerBoosts.Add("HealthBoost", HealthBoost);

        _timer = new Timer.Timer(_boostDuration);
    }

    private void OnEnable()
    {
        _timer.OnTimerFinishedEvent += DeactivateSizeBoost;
    }

    private void OnDisable()
    {
        _timer.OnTimerFinishedEvent -= DeactivateSizeBoost;
    }

    public void Init(PlayerLifebar playerLifebar)
    {
        _playerLifebar = playerLifebar;
    }

    public Action SetBoost(string key)
    {
        _timer.Start(_boostDuration);

        return _playerBoosts[key];
    }

    private void SizeBoost()
    {
        transform.localScale = new Vector3(2, 2, 1);
    }

    private void HealthBoost()
    {
        _playerLifebar.IncreaseHealth();
    }

    private void DeactivateSizeBoost()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
