using System;
using UnityEngine;

namespace Fader
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static Fader _instance;

        public static Fader instance
        {
            get
            {
                if (_instance == null)
                {
                    var prefab = Resources.Load<Fader>("Fader/Fader");
                    _instance = Instantiate(prefab);
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        public bool isFading { get; private set; }
        private Action _fadedInCallBack;

        private Action _fadedOutCallBack;

        public void FadeIn(Action fadedInCallBack)
        {
            if (isFading)
                return;

            isFading = true;
            _fadedInCallBack = fadedInCallBack;
            _animator.SetBool("faded", true);
        }

        public void FadeOut(Action fadedOutCallBack)
        {
            if (isFading)
                return;

            isFading = true;
            _fadedOutCallBack = fadedOutCallBack;
            _animator.SetBool("faded", false);
        }

        private void Handle_FadeInAnimationOver()
        {
            _fadedInCallBack?.Invoke();
            _fadedInCallBack = null;
            isFading = false;
        }

        private void Handle_FadeOutAnimationOver()
        {
            _fadedOutCallBack?.Invoke();
            _fadedOutCallBack = null;
            isFading = false;
        }
    }
}
