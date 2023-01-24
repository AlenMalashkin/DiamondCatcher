using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Factories;

namespace Location
{
    public class InitLocation : MonoBehaviour
    {
        [SerializeField] private DefaultItemFactory[] _itemFactories;

        [SerializeField] private SpriteRenderer _ground;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private GameObject _boss;

        private Dictionary<string, LocationParams> _locationParams;

        private void Awake()
        {
            _locationParams = new Dictionary<string, LocationParams>();

            #region Add locations to dictionary
            _locationParams.Add("WoodLocation", Resources.Load<LocationParams>("Locations/WoodLocation"));
            _locationParams.Add("StoneLocation", Resources.Load<LocationParams>("Locations/StoneLocation"));
            _locationParams.Add("NetherLocation", Resources.Load<LocationParams>("Locations/NetherLocation"));
            _locationParams.Add("StrongholdLocation", Resources.Load<LocationParams>("Locations/StrongholdLocation"));
            _locationParams.Add("EndLocation", Resources.Load<LocationParams>("Locations/EndLocation"));
            _locationParams.Add("EndDragonLocation", Resources.Load<LocationParams>("Locations/EndDragonLocation"));
            #endregion

            var currentLocationParams = _locationParams[PlayerPrefs.GetString("CurrentLocation")];

            for (int i = 0; i < _itemFactories.Length; i++)
            {
                _itemFactories[i].Init(currentLocationParams.currencies,
                                        currentLocationParams.startMinSpeed,
                                        currentLocationParams.startMaxSpeed, 
                                        currentLocationParams.minSpeed,
                                        currentLocationParams.maxSpeed);
            }
            
            _ground.sprite = currentLocationParams.ground;
            _background.sprite = currentLocationParams.background;

            if (currentLocationParams.isBossLocation)
            {
                _boss.SetActive(true);
            }
        }
    }

}
