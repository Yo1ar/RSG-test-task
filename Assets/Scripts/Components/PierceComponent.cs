using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Components
{
    public class PierceComponent : MonoBehaviour
    {
        public UnityEvent _onPierceEvent;
        public UnityEvent _onNotPierceEvent;
        [SerializeField] private int _chanceToPierce;
        private const int _basicPierceChance = 10;
        private HealthComponent _playerHealthComponent;

        private void Start()
        {
            _playerHealthComponent = GameObject.FindWithTag("Player").GetComponent<HealthComponent>();
            _chanceToPierce = _basicPierceChance +
                              (_playerHealthComponent.MaxHealth - _playerHealthComponent.CurrentHealth);
            Mathf.Clamp(_chanceToPierce, _basicPierceChance, 100);
        }

        public void Pierce()
        {
            Mathf.Clamp(_chanceToPierce, _basicPierceChance, 100);

            var randomValue = Random.Range(1, 100 + 1);
            if (randomValue <= _chanceToPierce)
            {
                _onNotPierceEvent?.Invoke();
            }
            else
            {
                _onPierceEvent?.Invoke();
            }
        }
    }
}