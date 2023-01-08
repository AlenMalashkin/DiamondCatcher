using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public class BoostItemFactoryInvoker : FactoryInvokerAbstract
    {
        [SerializeField] private BoostItemFactory _boostItemFactory;
        [SerializeField] private float minTimeToSpawn;

        public override void Create()
        {
            var item = _boostItemFactory.Spawn();
        }

        public override void OnTimerFinished()
        {
            var time = Random.Range(minTimeToSpawn, timeToSpawnItem);

            StartTimer(time);
            Create();
        }

        public override void OnTimerValueChaned(float remainingSeconds)
        {
            if (timeToSpawnItem < 60f)
                timeToSpawnItem += 0.01f;
        }
    }
}

