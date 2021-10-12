using UnityEngine;
using UnityEngine.InputSystem;

namespace Components
{
    public class PowerComponent : MonoBehaviour
    {
        private int _maxPower;
        public int MaxPower => _maxPower;
        [SerializeField] private int _currentPower;
        public int CurrentPower => _currentPower;

        // [Header("Events")]
        // [SerializeField] private UnityEvent _onPowerLost;
        // [SerializeField] private UnityEvent _onPowerGain;


        private void Start()
        {
            _currentPower = _maxPower;
        }

        public void InitPowerData(int maxPower)
        {
            _maxPower = maxPower;
        }
        
        public void ModifyPower(int amount)
        {
            if (_currentPower <= 0) return;

            if (_currentPower + amount > _maxPower)
                _currentPower = _maxPower;
            else
                _currentPower += amount;
            
            // if (amount < 0)
            //     _onPowerTaken?.Invoke();
            // else
            //     _onHeal?.Invoke();
            //
            // if (_currentPower <= 0)
            //     _onDeath?.Invoke();
        }

        public void OnUltimateInput(InputAction.CallbackContext context)
        {
            EliminateEveryone();
        }

        private bool IsUltimateReady()
        {
            return _currentPower == _maxPower;
        }

        private void EliminateEveryone()
        {
            if (!IsUltimateReady()) return;
            
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }

            ModifyPower(-_maxPower);
        }
    }
}