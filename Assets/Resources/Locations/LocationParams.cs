using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "Location", menuName = "Location Params", order = 0)]
    public class LocationParams : ScriptableObject
    {
        [SerializeField] private List<Currency.Currency> _currencies;
        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _ground;
        [SerializeField] private string _recordSavePath;
        [SerializeField] private string _locationName;
        [SerializeField] private float _startMinSpeed;
        [SerializeField] private float _startMaxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private bool _isBossLocation;

        public List<Currency.Currency> currencies => _currencies;
        public Sprite background => _background;
        public Sprite ground => _ground;
        public string recordSavePath => _recordSavePath;
        public string locationName => _locationName;
        public float startMinSpeed => _startMinSpeed;
        public float startMaxSpeed => _startMaxSpeed;
        public float minSpeed => _minSpeed;
        public float maxSpeed => _maxSpeed;
        public bool isBossLocation => _isBossLocation;
    }   
}

