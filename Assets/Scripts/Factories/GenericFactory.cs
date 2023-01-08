using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public abstract class GenericFactory<T> : MonoBehaviour where T : Item
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _spawnPoint;

        public virtual T Spawn()
        {
            Vector3 pos = new Vector3(_spawnPoint.position.x + Random.Range(0f, 5f),
                                        _spawnPoint.position.y + Random.Range(0f, 5f),
                                        _spawnPoint.position.z + Random.Range(0f, 5f));

            return Instantiate(_prefab, pos, Quaternion.identity);
        }
    }
}
