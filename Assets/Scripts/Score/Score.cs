using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timer = Timer.Timer;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _addScorePerSecond;
    private float _score;

    public float score => _score;
    
    private void Update()
    {
        _score += _addScorePerSecond * Time.deltaTime;
        _scoreText.text = Mathf.Round(_score).ToString();
    }
}
