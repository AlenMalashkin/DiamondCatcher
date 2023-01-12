using System;
using System.Collections;
using System.Collections.Generic;
using Location;
using UnityEngine;

namespace PlayerProfile
{
    public class ViewRecords : MonoBehaviour
    {
        [SerializeField] private LocationParams[] _locationParams;
        [SerializeField] private RecordCard _recordCardPrefab;

        private void Awake()
        {
            for (int i = 0; i < _locationParams.Length; i++)
            {
                var item = Instantiate(_recordCardPrefab, transform, true);
                
                item.Init(_locationParams[i]);
                
                item.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}