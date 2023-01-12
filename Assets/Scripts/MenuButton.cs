
using System;
using System.Collections;
using System.Collections.Generic;
using Fader;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        FaderInvoker.instance.LoadScene(_sceneName);
    }
}
