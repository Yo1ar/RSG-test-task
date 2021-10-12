using System;
using System.Reflection;
using Characters.Player;
using Components;
using ScriptableObjects;
using UnityEngine;

namespace Characters
{
    public class RedEnemyComponent : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO _enemyData;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private bool _isTopFlyPointReached;
        [SerializeField] private int _powerForDeath;
        private float _speed;
        private Vector3 _startPosition;
        private Transform _target;
        private Vector3 _direction;
        

        private void Start()
        {
            InitEnemyData();
        }

        private void InitEnemyData()
        {
            _startPosition = transform.position;
            _target = GameObject.Find("Player").transform;
            _speed = _enemyData.EnemySpeed;

            if (TryGetComponent(out MeshRenderer meshRenderer))
                meshRenderer.material = _enemyData.EnemyMaterial;

            if (TryGetComponent(out HealthComponent healthComponent))
                healthComponent.SetHealth(_enemyData.EnemyHealth);
        }

        private void Update()
        {
            if (transform.position.y - _startPosition.y > 7f)
            {
                _isTopFlyPointReached = true;
                _startPosition = transform.position;
                _direction = (_target.position - _startPosition).normalized;
            }
            
            if (!_isTopFlyPointReached)
            {
                _rigidbody.MovePosition(transform.position + Vector3.up * (_speed * Time.fixedDeltaTime));
            }
            else
            {
                _rigidbody.MovePosition(transform.position + _direction * (_speed * 10f * Time.fixedDeltaTime));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Arena")) return;
            _isTopFlyPointReached = false;
            _startPosition.y = 0f;
        }

        private void OnDestroy()
        {
            ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
            if (scoreCounter!=null)
                scoreCounter.AddScore();
            
            PowerComponent powerComponent = FindObjectOfType<PowerComponent>();
            if (powerComponent!=null)
                powerComponent.ModifyPower(_powerForDeath);
        }
    }
}