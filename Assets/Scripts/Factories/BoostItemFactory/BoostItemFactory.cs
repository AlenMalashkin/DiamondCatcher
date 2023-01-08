using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class BoostItemFactory : GenericFactory<BoostItem>
    {
        [SerializeField] private Boosters.BoostData[] _boosts;

        public override BoostItem Spawn()
        {
            var item = base.Spawn();

            var index = Random.Range(0, _boosts.Length);

            item.Init(3f, 
                    _boosts[index].sprite,
                    _boosts[index].boostName);

            return item;
        }
    }
}
