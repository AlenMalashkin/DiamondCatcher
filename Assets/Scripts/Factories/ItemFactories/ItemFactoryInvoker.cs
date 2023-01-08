using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class ItemFactoryInvoker : FactoryInvokerAbstract
    {
        [SerializeField] private DefaultItemFactory[] _defaultFactories;

        public override void Create()
        {
            for (int i = 0; i < _defaultFactories.Length; i++)
            {
                _defaultFactories[i].Spawn();
            }
        }

        public override void OnTimerValueChaned(float remainingSeconds)
        {
            for (int i = 0; i < _defaultFactories.Length; i++)
            {
                _defaultFactories[i].IncreaseItemSpeed();
            }

            if (timeToSpawnItem > 2f)
            {
                timeToSpawnItem -= 0.01f;
            }
        }

        public override void OnTimerFinished()
        {
            StartTimer(timeToSpawnItem);
            Create();
        }
    }
}

