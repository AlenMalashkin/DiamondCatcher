using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Currency;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Product> _products;
        [SerializeField] private ProductCard _productPrefab;
        [SerializeField] private Bank _bank;
        [SerializeField] private ViewCurrency _viewCurrency;

        private void Awake()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                var product = Instantiate(_productPrefab);

                product.InitProductCard(_products[i].image, 
                                        _products[i].currency, 
                                        _bank, 
                                        _viewCurrency,
                                        _products[i].productName,
                                        _products[i].cost, 
                                        _products[i].playerPrefsSaveName);

                product.transform.SetParent(transform);
                product.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}