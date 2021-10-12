using System;
using UnityEngine;

namespace Components
{
    public class DestroyComponent : MonoBehaviour
    {
        [SerializeField] private float _destroyTimer;

        private void Start()
        {
            DestroyThisGO();
        }

        private void DestroyThisGO()
        {
            if (_destroyTimer == 0) return;
            
            Destroy(this.gameObject, _destroyTimer);
        }
        
        public void DestroyImmediately()
        {
            Destroy(this.gameObject);
        }
        
        public void DestroyImmediately(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}