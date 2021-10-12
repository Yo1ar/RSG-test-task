using UnityEngine;

namespace Components
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;

        [Header("Events")] [SerializeField] private UnityEventGO _onCollisionEnterEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
                _onCollisionEnterEvent?.Invoke(collision.gameObject);
        }
    }
}