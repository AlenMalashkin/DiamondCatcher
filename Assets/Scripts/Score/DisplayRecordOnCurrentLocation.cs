using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRecordOnCurrentLocation : MonoBehaviour
{
    [SerializeField] private Text _recordScore;
     
    private void Awake()
    {
        _recordScore.text = "Рекорд: " + Mathf.Round(PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentLocation") + "Record")).ToString();
    }
}
