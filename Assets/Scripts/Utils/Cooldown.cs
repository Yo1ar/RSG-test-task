using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] private float _cooldownValue;
        private float _cooldownCompleteTime;

        public Cooldown(float cooldownValue)
        {
            if (_cooldownValue == 0f)
                _cooldownValue = cooldownValue;
        }
        
        public void Reset()
        {
            _cooldownCompleteTime = Time.time + _cooldownValue;
        }

        public bool isReady => _cooldownCompleteTime <= Time.time;
    }
}