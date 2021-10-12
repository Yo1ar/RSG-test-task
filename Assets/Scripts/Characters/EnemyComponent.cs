using Characters.Player;
using Components;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Characters
{
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField] private EnemyDataSO _enemyData;
        [SerializeField] private Rigidbody _shotPrefab;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private int _powerForDeath;
        private FollowComponent _followComponent;
        private GameObject _spawnContainer;

        private void Start()
        {
            InitEnemyData();
        }

        private void InitEnemyData()
        {
            _spawnContainer = GameObject.Find("==== SPAWN CONTAINER");
            if (TryGetComponent(out _followComponent))
                _followComponent.SetFollowSpeed(_enemyData.EnemySpeed);

            if (TryGetComponent(out MeshRenderer meshRenderer))
                meshRenderer.material = _enemyData.EnemyMaterial;

            if (TryGetComponent(out HealthComponent healthComponent))
                healthComponent.SetHealth(_enemyData.EnemyHealth);
        }

        private void FixedUpdate()
        {
            Shot();
        }

        [ContextMenu("Shot")]
        public void Shot()
        {
            if (!_cooldown.isReady) return;

            Instantiate(_shotPrefab, _shotPoint.position, _shotPoint.rotation, _spawnContainer.transform);

            _cooldown.Reset();
        }

        private void OnDestroy()
        {
            ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
            if (scoreCounter != null)
                scoreCounter.AddScore();
                        
            PowerComponent powerComponent = FindObjectOfType<PowerComponent>();
            if (powerComponent!=null)
                powerComponent.ModifyPower(_powerForDeath);
        }
    }
}