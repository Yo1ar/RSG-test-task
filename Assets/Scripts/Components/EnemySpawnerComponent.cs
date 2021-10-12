using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class EnemySpawnerComponent : MonoBehaviour
    {
        [SerializeField] private int _totalWaves;
        [SerializeField] private float _waveDuration;
        [SerializeField] private int _enemyCount;
        [SerializeField] private EnemySpawnData[] _enemiesPrefabs;
        [SerializeField] private Vector3 _point1;
        [SerializeField] private Vector3 _point2;
        private int _globalWeight;
    
        
        private void Start()
        {
            foreach (EnemySpawnData spawnData in _enemiesPrefabs)
            {
                _globalWeight += spawnData.Weight;
            }
            
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            for (int i = 0; i < _totalWaves; i++)
            {
                Spawn();
                
                yield return new WaitForSeconds(_waveDuration);
            
                if (_waveDuration > 2f) _waveDuration -= 0.5f;
                else _waveDuration = 2f;
                
                if (_waveDuration == 2f)
                    _enemyCount++;
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                GameObject enemy = GetRandomEnemy(_enemiesPrefabs);
                if (enemy == null) continue;
                
                Vector3 newSpawnPosition = GetRandomSpawnPosition();
                Instantiate(enemy, newSpawnPosition, Quaternion.identity);
            }
        }

        private GameObject GetRandomEnemy(EnemySpawnData[] enemyCollection)
        {
            GameObject selected = null;
            int tempGlobalWeight = _globalWeight;

            foreach (EnemySpawnData enemyData in enemyCollection)
            {
                int weight = enemyData.Weight;

                if (Random.Range(1, tempGlobalWeight + 1) <= weight)
                {
                    selected = enemyData.EnemyPrefab;
                    break;
                }
                else
                {
                    tempGlobalWeight -= weight;
                }
            }

            return selected;
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(_point1.x, _point2.x); 
            float randomZ = Random.Range(_point1.z, _point2.z);
            var randomSpawnPosition = new Vector3(randomX, 1f, randomZ);
            
            return randomSpawnPosition;
        }
    }

    [Serializable]
    public class EnemySpawnData
    {
        [SerializeField] private GameObject _enemyPrefab;
        public GameObject EnemyPrefab => _enemyPrefab;
        [SerializeField] private int _weight;
        public int Weight => _weight;
    }
}
