using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Factories;

namespace Location
{
    public class InitLocation : MonoBehaviour
    {
        [SerializeField] private DefaultItemFactory _itemFactory;

        [SerializeField] private SpriteRenderer _ground;
        [SerializeField] private SpriteRenderer _background;

        private Dictionary<string, LocationParams> _locationParams;

        private void Awake()
        {
            _locationParams = new Dictionary<string, LocationParams>();

            #region Add locations to dictionary
            _locationParams.Add("WoodLocation", Resources.Load<LocationParams>("Locations/WoodLocation"));
            _locationParams.Add("StoneLocation", Resources.Load<LocationParams>("Locations/StoneLocation"));
            #endregion

            var currentLocationParams = _locationParams[PlayerPrefs.GetString("CurrentLocation")];

            _itemFactory.InitSpritesList(currentLocationParams.currencies);
            
            _ground.sprite = currentLocationParams.ground;
            _background.sprite = currentLocationParams.background;
        }
    }

}
