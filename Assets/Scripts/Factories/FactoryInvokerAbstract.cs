using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public abstract class FactoryInvokerAbstract : MonoBehaviour
    {
        private Timer.Timer _timer;
        public float timeToSpawnItem;

        private void Start()
        {
            _timer = new Timer.Timer(timeToSpawnItem);
            StartTimer(timeToSpawnItem);
            _timer.OnTimerValueChanedEvent += OnTimerValueChaned;
            _timer.OnTimerFinishedEvent += OnTimerFinished;
        }

        private void OnDestroy()
        {
            _timer.OnTimerValueChanedEvent -= OnTimerValueChaned;
            _timer.OnTimerFinishedEvent -= OnTimerFinished;
        }

        public abstract void Create();

        public abstract void OnTimerValueChaned(float remainingSeconds);

        public abstract void OnTimerFinished();

        public void StartTimer(float time)
        {
            _timer.Start(time);
        }

        public void StopTimer()
        {
            _timer.Stop();
        }
    }    
}

