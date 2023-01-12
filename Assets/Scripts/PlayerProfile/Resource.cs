using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerProfile
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Image _resourceImage;
        [SerializeField] private Text _resourceTotalCountText;
        
        public void Init(Currency.Currency resource)
        {
            _resourceImage.sprite = resource.sprite;
            _resourceTotalCountText.text = PlayerPrefs.GetInt(resource.playerPrefsName + "Total", 0).ToString();
        }
    }
}