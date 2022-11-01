using UnityEngine;

namespace FallingItems
{
    public class ItemsSpawnArea : MonoBehaviour
    {
        [SerializeField] private int poolCount = 3;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Item prefab;
        [SerializeField] private float secondsRemain;

        private Timer.Timer _timer;

        private FallingItemsPool<Item> pool;

        private void Start()
        {
            _timer = new Timer.Timer(secondsRemain);
            StartTimer();
            _timer.OnTimerValueChanedEvent += OnTimerValueChaned;
            _timer.OnTimerFinishedEvent += OnTimerFinished;

            pool = new FallingItemsPool<Item>(prefab, poolCount, transform);
            pool.autoExpand = autoExpand;
        }

        private void OnDestroy()
        {
            _timer.OnTimerValueChanedEvent -= OnTimerValueChaned;
            _timer.OnTimerFinishedEvent -= OnTimerFinished;
        }

        private void CreateFallingItem()
        {
            var rX = Random.Range(-10f, 10f);
            var rY = Random.Range(5f, 10f);

            var rPos = new Vector2(rX, rY);
            var item = pool.GetFreeElement();
            item.transform.position = rPos;
        }

        private void StartTimer()
        {
            _timer.Start();
        }

        private void PauseTimer()
        {
            if (_timer.isPaused)
                _timer.Resume();
            else
                _timer.Pause();
        }

        private void StopTimer()
        {
            _timer.Stop();
        }

        private void OnTimerValueChaned(float remainingSeconds)
        {
            if (secondsRemain >= 1.5f)
                secondsRemain -= 0.02f;
        }

        private void OnTimerFinished()
        {
            _timer.Start(secondsRemain);
            CreateFallingItem();
        }
    }
}

