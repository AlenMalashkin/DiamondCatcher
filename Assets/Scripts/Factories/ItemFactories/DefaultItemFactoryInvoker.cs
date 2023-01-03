using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class DefaultItemFactoryInvoker : MonoBehaviour
    {
        [SerializeField] private DefaultItemFactory _factory;
        [SerializeField] private float timeToSpawnDefaultItem;

        private Timer.Timer _timer;

        private void Start()
        {
            _timer = new Timer.Timer(timeToSpawnDefaultItem);
            StartTimer();
            _timer.OnTimerValueChanedEvent += OnTimerValueChaned;
            _timer.OnTimerFinishedEvent += OnTimerFinished;
        }

        private void OnDestroy()
        {
            _timer.OnTimerValueChanedEvent -= OnTimerValueChaned;
            _timer.OnTimerFinishedEvent -= OnTimerFinished;
        }

        private void Create()
        {
            var item = _factory.Spawn();
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public void OnTimerValueChaned(float remainingSeconds)
        {
            if (timeToSpawnDefaultItem >= 1.25f)
                timeToSpawnDefaultItem -= 0.01f;
        }

        public void OnTimerFinished()
        {
            _timer.Start(timeToSpawnDefaultItem);
            Create();
        }
    }
}

