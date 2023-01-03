using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Shop
{
    public class ViewCurrency : MonoBehaviour
    {
        [SerializeField] private List<Currency.Currency> _currencies;
        [SerializeField] private CurrencyUI _resourcePrefab;

        private void Awake()
        {
            _currencies = Resources.LoadAll<Currency.Currency>("Currency").ToList();

            CreateCurrencyUI();
        }

        public void UpdateUI()
        {
            DestroyAllCurrnecyUI();
            CreateCurrencyUI();
        }

        private void CreateCurrencyUI()
        {
            for (int i = 0; i < _currencies.Count; i++)
            {
                var resource = Instantiate(_resourcePrefab);

                resource.Init(_currencies[i].sprite, PlayerPrefs.GetInt(_currencies[i].playerPrefsName));

                resource.transform.SetParent(transform);
                resource.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void DestroyAllCurrnecyUI()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }    
}

