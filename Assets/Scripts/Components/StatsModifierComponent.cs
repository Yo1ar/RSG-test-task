using UnityEngine;

namespace Components
{
    public class StatsModifierComponent : MonoBehaviour
    {
        private enum WhatModifies{ Health,Power}

        [SerializeField] private WhatModifies _whatModify;
        [SerializeField] private int _amount;

        public void Modify(GameObject target)
        {
            if (_whatModify == WhatModifies.Health)
            {
                target.TryGetComponent(out HealthComponent modifiedComponent);
                if (modifiedComponent != null)
                    modifiedComponent.ModifyHealth(_amount);
            }
            else
            {
                target.TryGetComponent(out PowerComponent modifiedComponent);
                if (modifiedComponent != null)
                    modifiedComponent.ModifyPower(_amount);
            }
        }
    }
}