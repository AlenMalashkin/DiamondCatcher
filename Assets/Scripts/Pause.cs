using Scenes;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _backButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(ActivatePause);
        _resumeButton.onClick.AddListener(Resume);
        _backButton.onClick.AddListener(Back);
    }

    private void ActivatePause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Back()
    {
        SceneLoader.instance.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
