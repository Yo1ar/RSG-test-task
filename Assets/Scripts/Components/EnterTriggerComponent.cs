using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;

        [Header("Events")]
        [SerializeField] private UnityEventGO _onTriggerEnterEvent;

        private void OnTriggerEnter(Collider collision)
        {
            if (!string.IsNullOrEmpty(_tag) && !collision.CompareTag(_tag)) return;
            
            _onTriggerEnterEvent?.Invoke(collision.gameObject);
        }
    }
}