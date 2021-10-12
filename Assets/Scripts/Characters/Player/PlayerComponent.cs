using Components;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Characters.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerComponent : MonoBehaviour
    {
        // Component fields
        [SerializeField] private PlayerDataSO _playerData;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private PowerComponent _powerComponent;
        private MeshRenderer _meshRenderer;

        //Shooting
        [SerializeField] private BulletDataSO _bullet;
        [SerializeField] private Rigidbody _shotPrefab;
        [SerializeField] private ForceMode _forceMode;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private Cooldown _cooldown;
        private GameObject _spawnContainer;
        private bool _isShooting;
        
        //Service fields
        [SerializeField] private int _startingPower;
        private Vector2 _moveDirection;


        private void Awake()
        {
            if (_playerData == null)
                Debug.LogError("There is no PlayerData attached to PlayerComponent");

            ApplyPlayerData();
            _spawnContainer = GameObject.Find("==== SPAWN CONTAINER");

        }

        private void FixedUpdate()
        {
            _playerMovement.MovePlayer(_playerData.MoveSpeed);
            Shot();
        }

        private void ApplyPlayerData()
        {
            GetComponents();
            _healthComponent.InitHealthData(_playerData.PlayerMaxHealth);
            _powerComponent.InitPowerData(_playerData.PlayerPower);
            InitShootData(_playerData.PlayerReloadSpeed);
            _meshRenderer.material = _playerData.PlayerMaterial;
        }

        private void GetComponents()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _healthComponent = GetComponent<HealthComponent>();
            _powerComponent = GetComponent<PowerComponent>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }
        

        #region SHOOTING

        private void InitShootData(float cooldown)
        {
            _cooldown = new Cooldown(cooldown);
        }

        private void Shot()
        {
            if (!_isShooting) return;
            if (!_cooldown.isReady) return;
            
            var prefab = Instantiate(_shotPrefab, _shotPoint.position, _shotPoint.rotation, _spawnContainer.transform) as Rigidbody;
            prefab.AddForce(_shotPoint.forward * _bullet.BulletSpeed, _forceMode);

            _cooldown.Reset();
        }
        
        public void OnShotPlayerInput(InputAction.CallbackContext context)
        {
            _isShooting = context.performed;
        }

        #endregion
    }
}