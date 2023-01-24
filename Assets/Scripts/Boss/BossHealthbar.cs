using FallingItems;
using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Boss
{
    public class BossHealthbar : MonoBehaviour
    {
        [SerializeField] private Slider _healthbar;
        [SerializeField] private Text _healthbarText;

        [SerializeField] private int _health;

        private Player _player;

        private void Start()
        {
            _healthbarText.text = _health.ToString();
            _healthbar.value = _health / 1000;
            _player.OnCollectItemEvent += TakeDamage;
        }

        private void OnDisable()
        {
            _player.OnCollectItemEvent -= TakeDamage;
        }

        public void Init(Player player)
        {
            _player = player;
        }

        private void TakeDamage(DefaultItem item)
        {
            _health -= item.GetCurrentItemDamage;
            
            if (_health <= 0) 
                SceneLoader.instance.LoadScene("WinScreen");
            
            _healthbar.value = (float) _health / 1000;
            _healthbarText.text = _health.ToString();
        }
    }    
}

