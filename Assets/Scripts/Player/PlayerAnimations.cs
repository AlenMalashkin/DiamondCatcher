using System;
using Lifebar;
using UnityEngine;


    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetDamagedAnimation()
        {
            _animator.SetTrigger("TakeDamage");
        }

        public void SetSizedAnimation()
        {
            _animator.SetBool("Sized", true);
        }

        public void SetShrinkAnimation()
        {
            _animator.SetBool("Sized", false);
        }
    }
