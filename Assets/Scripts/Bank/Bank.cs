using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Currency
{
    public class Bank : MonoBehaviour
    {
        public void AddResource(string resourceName, int amount)
        {
            var endAmount = PlayerPrefs.GetInt(resourceName);
            endAmount += amount;
            PlayerPrefs.SetInt(resourceName, endAmount);
        }

        public void SpendResource(string resourceName, int amount)
        {
            var endAmount = PlayerPrefs.GetInt(resourceName);
            endAmount -= amount;
            PlayerPrefs.SetInt(resourceName, endAmount);
        }
    }   
}

