using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _amount;

        public void Init(Sprite sprite, int amount)
        {
            _image.sprite = sprite;
            _amount.text = amount.ToString();
        }
    }
}