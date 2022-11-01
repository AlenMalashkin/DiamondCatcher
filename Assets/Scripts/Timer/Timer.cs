using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class Timer
    {
        public event Action<float> OnTimerValueChanedEvent;
        public event Action OnTimerFinishedEvent;

        public float remainingSeconds { get; private set; }
        public bool isPaused { get; private set; }

        public Timer(float seconds)
        {
            SetTime(seconds);
        }

        public void SetTime(float seconds)
        {
            remainingSeconds = seconds;
            OnTimerValueChanedEvent?.Invoke(seconds);
        }

        public void Start()
        {
            if (remainingSeconds == 0)
            {
                Debug.LogError("You can not start timer with remain seconds 0");
                OnTimerFinishedEvent?.Invoke();
            }

            isPaused = false;
            Subscribe();
            OnTimerValueChanedEvent?.Invoke(remainingSeconds);
        }

        public void Start(float seconds)
        {
            SetTime(seconds);
            Start();
        }

        public void Pause()
        {
            isPaused = true;
            Unsubscribe();
            OnTimerValueChanedEvent?.Invoke(remainingSeconds);
        }

        public void Resume()
        {
            isPaused = false;
            Subscribe();
            OnTimerValueChanedEvent?.Invoke(remainingSeconds);
        }

        public void Stop()
        {
            Unsubscribe();
            remainingSeconds = 0;

            OnTimerValueChanedEvent?.Invoke(remainingSeconds);
            OnTimerFinishedEvent?.Invoke();
        }

        private void Subscribe()
        {
            TimeInvoker.instance.OnOneSecondTickedEvent += OnOneSecondTicked;
        }

        private void Unsubscribe()
        {
            TimeInvoker.instance.OnOneSecondTickedEvent -= OnOneSecondTicked;
        }

        private void OnOneSecondTicked()
        {
            if (isPaused)
                return;

            remainingSeconds -= 1;

            CheckFinish();
        }

        private void CheckFinish()
        {
            if (remainingSeconds <= 0)
                Stop();
            else
                OnTimerValueChanedEvent?.Invoke(remainingSeconds);
        }
    } 
}

