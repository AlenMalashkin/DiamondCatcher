using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class TimeInvoker : MonoBehaviour
    {
        public event Action OnOneSecondTickedEvent;

        public static TimeInvoker instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("TIME_INVOKER");
                    _instance = go.AddComponent<TimeInvoker>();
                    DontDestroyOnLoad(go);
                }

                return _instance;
            }
        }

        private static TimeInvoker _instance;

        private float _oneSecTimer;

        private void Update()
        {
            var deltaTime = Time.deltaTime;

            _oneSecTimer += deltaTime;
            if (_oneSecTimer > 1)
            {
                _oneSecTimer -= 1;
                OnOneSecondTickedEvent?.Invoke();
            }
        }
    }
}
