using Scenes;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadScene);
        //_button.onClick.AddListener(SoundInvoker.instance.PlayOnButtonClickClip);
    }

    private void LoadScene()
    {
        SceneLoader.instance.LoadScene(_sceneName);
    }
}
