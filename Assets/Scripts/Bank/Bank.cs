using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Currency
{
    public class Bank : MonoBehaviour
    {
        public void AddResource(string resourceName)
        {
            var amount = PlayerPrefs.GetInt(resourceName);
            amount += 1;
            PlayerPrefs.SetInt(resourceName, amount);
        }

        public void SpendResource(string resourceName, int amount)
        {
            var endAmount = PlayerPrefs.GetInt(resourceName);
            endAmount -= amount;
            PlayerPrefs.SetInt(resourceName, endAmount);
        }
    }   
}

