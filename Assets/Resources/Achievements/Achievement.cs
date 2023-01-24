using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "Add Achievements", order = 5)]
    public class Achievement : ScriptableObject
    {
        [SerializeField] private Currency.Currency _claimResource;
        [SerializeField] private Currency.Currency _rewardResource;
        [SerializeField] private string _description;
        [SerializeField] private string _savePath;
        [SerializeField] private int[] _claimResourceCount;
        [SerializeField] private int[] _rewardResourceCount;

        public Currency.Currency claimResource => _claimResource;
        public Currency.Currency rewardResource => _rewardResource;
        public string description => _description;
        public string savePath => _savePath;
        public int[] claimResourceCount => _claimResourceCount;
        public int[] rewardResourceCount => _rewardResourceCount;
    }
}