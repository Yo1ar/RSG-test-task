using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _currentHealth;
        public int CurrentHealth => _currentHealth;
        private int _maxHealth;
        public int MaxHealth => _maxHealth;
        
        [Header("Events")]
        [SerializeField] private UnityEvent _onDamageTaken;

        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDeath;
        [SerializeField] private HealthChangeEvent _healthChangeEvent;


        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void InitHealthData(int maxHealth)
        {
            _maxHealth = maxHealth;
        }
        
        public void ModifyHealth(int amount)
        {
            if (_currentHealth <= 0) _onDeath?.Invoke();

            if (_currentHealth + amount > _maxHealth)
                _currentHealth = _maxHealth;
            else
                _currentHealth += amount;
            
            _healthChangeEvent?.Invoke(_currentHealth);
            
            if (amount < 0)
                _onDamageTaken?.Invoke();
            else
                _onHeal?.Invoke();
            
            if (_currentHealth <= 0)
                _onDeath?.Invoke();
        }

        public void SetHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
        }
        
        private void OnDestroy() => _onDeath.RemoveAllListeners();
        
        [Serializable]
        internal class HealthChangeEvent : UnityEvent<int>
        {
        }
    }

}