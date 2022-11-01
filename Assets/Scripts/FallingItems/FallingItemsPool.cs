using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public class FallingItemsPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Transform _spawnArea;
        public bool autoExpand { get; set; }

        private List<T> pool;

        public FallingItemsPool(T prefab, int count)
        {
            _prefab = prefab;
            _spawnArea = null;

            CreatePool(count);
        }

        public FallingItemsPool(T prefab, int count, Transform spawnArea)
        {
            _prefab = prefab;
            _spawnArea = spawnArea;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefult = false)
        {
            var createdObject = Object.Instantiate(_prefab, _spawnArea);
            createdObject.gameObject.SetActive(isActiveByDefult);
            pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;
            
            if (autoExpand)
                return CreateObject(true);

            throw new System.Exception($"No free elements in pool {typeof(T)}");
        }
    }
}

