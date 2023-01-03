using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private List<Transform> _spawnPoints;

        public virtual T Spawn()
        {
            var index = Random.Range(0, _spawnPoints.Count);

            Vector3 pos = new Vector3(_spawnPoints[index].position.x + Random.Range(0, 5),
                                        _spawnPoints[index].position.y + Random.Range(0, 5),
                                        _spawnPoints[index].position.z + Random.Range(0, 5));

            return Instantiate(_prefab, pos, Quaternion.identity);
        }
    }
}
