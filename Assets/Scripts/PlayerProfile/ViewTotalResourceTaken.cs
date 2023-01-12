using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerProfile
{
    public class ViewTotalResourceTaken : MonoBehaviour
    {
        [SerializeField] private Currency.Currency[] _resources;
        [SerializeField] private Resource _resourcePrefab;

        private void Awake()
        {
            for (int i = 0; i < _resources.Length; i++)
            {
                var item = Instantiate(_resourcePrefab, transform, true);

                item.Init(_resources[i]);
                
                item.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}