using UnityEngine;

namespace Factories
{
    public class ItemFactoryInvoker : FactoryInvokerAbstract
    {
        [SerializeField] private DefaultItemFactory _defaultFactory;
        [SerializeField] private float _currentMinTimeToSpawn;
        [SerializeField] private float _minTimeToSpawn;
        [SerializeField] private float _currentMaxTimeToSpawn;
        [SerializeField] private float _maxTimeToSpawn;

        public override void Create()
        {
            _defaultFactory.Spawn();
        }

        public override void OnTimerValueChanged(float remainingSeconds)
        {
                _defaultFactory.IncreaseItemSpeed();

            if (_currentMinTimeToSpawn > _minTimeToSpawn)
                _currentMinTimeToSpawn -= 0.01f;

            if (_currentMaxTimeToSpawn > _maxTimeToSpawn)
                _currentMaxTimeToSpawn -= 0.01f;
        }

        public override void OnTimerFinished()
        {
            timeToSpawnItem = Random.Range(_currentMinTimeToSpawn, _currentMaxTimeToSpawn);
            StartTimer(timeToSpawnItem);
            Create();
        }
    }
}

