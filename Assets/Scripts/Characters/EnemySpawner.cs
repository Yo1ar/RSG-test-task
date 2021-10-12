// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Characters
// {
//     public class EnemySpawner : MonoBehaviour
//     {
//         public event EventHandler OnLevelEnd;
//
//         [SerializeField] private EnemyWave[] _enemyWaves = new EnemyWave[4];
//         [SerializeField] private Vector3 _spawnBoundX
//
//         private int _currentWave = 0;
//         private int _enemiesInWave = 0;
//         private List<Transform> _spawnedEnemyList = new List<Transform>();
//
//         private void Start()
//         {
//             SetupWave();
//
//             Subscribe_OnLevelEnd();
//             //InvokeRepeating("MethodName", time, repeatRate); // Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
//         }
//
//         private void Update()
//         {
//             SetupWave();
//         }
//
//         //Если не осталось врагов для спавна и в живых, устанавливает волну
//         private void SetupWave()
//         {
//             if (IsNoEnemiesToSpawnOrInList())
//             {
//                 SetCurrentWave();
//             }
//         }
//
//         //Очищает список заспавненных врагов
//         //Если текущая волна >= 3, выводит победную надпись
//         //Иначе:
//         //  увеличивает текующую волну
//         //  устанавливает количество врагов в волне
//         //  запускает спавн врагов
//         private void SetCurrentWave()
//         {
//             _spawnedEnemyList.Clear();
//
//             if (_currentWave < _enemyWaves.Length)
//             {
//                 Debug.Log(_enemyWaves[_currentWave].GetWaveName());
//                 _enemiesInWave = _enemyWaves[_currentWave].GetEnemiesInWave();
//
//                 StartCoroutine(SpawnEnemy());
//             }
//             else
//             {
//                 OnLevelEnd?.Invoke(this, EventArgs.Empty);
//                 UnsubscribeAll_OnLevelEnd();
//             }
//         }
//
//         //Спавнит врага
//         //Уменьшает кол-во необхходимых для спавна врагов в волне
//         //Записывает врага в список заспавненных
//         private IEnumerator SpawnEnemy()
//         {
//             while (_enemiesInWave != 0)
//             {
//                 EnemyController randomEnemy = _enemyWaves[_currentWave].GetRandomEnemyPrefab().GetComponent<EnemyController>();
//                 Transform randomSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
//
//                 Transform enemy = randomEnemy.InstantiateEnemy(randomSpawnPoint).transform;
//
//                 _enemiesInWave -= 1;
//                 _spawnedEnemyList.Add(enemy);
//
//                 float secondsToNextEnemy = _enemyWaves[_currentWave].GetWaveSpawnRate();
//                 yield return new WaitForSeconds(secondsToNextEnemy);
//             }
//
//             _currentWave += 1;
//             yield return null;
//         }
//
//         private bool IsNoEnemiesToSpawnOrInList()
//         {
//             if (IsEnemyListIsNull() && _enemiesInWave == 0)
//                 return true;
//             else
//                 return false;
//         }
//
//         private bool IsEnemyListIsNull()
//         {
//             for (int i = 0; i < _spawnedEnemyList.Count; i++)
//             {
//                 if (_spawnedEnemyList[i] != null)
//                     return false;
//             }
//
//             return true;
//         }
//
//         private void Subscribe_OnLevelEnd()
//         {
//             OnLevelEnd += ShowWinText_OnLevelEnd;
//             OnLevelEnd += StopSpawnCouroutine_OnLevelEnd;
//         }
//
//         private void UnsubscribeAll_OnLevelEnd()
//         {
//             OnLevelEnd -= ShowWinText_OnLevelEnd;
//             OnLevelEnd -= StopSpawnCouroutine_OnLevelEnd;
//         }
//
//         private void ShowWinText_OnLevelEnd(object sender, EventArgs e) => Debug.Log("You Win!");
//         private void StopSpawnCouroutine_OnLevelEnd(object sender, EventArgs e) => StopCoroutine(SpawnEnemy());
//
//     }
//
//     [Serializable]
//     public class EnemyWave
//     {
//         [SerializeField] private string _waveName; //Имя волны
//         [SerializeField] private GameObject[] _enemyPrefabs; //Префаб врага
//         [SerializeField] private float _enemyStrengthMultiplier = 1f; //Усиление врага
//         [SerializeField] private int _enemiesInWave = 0; //Кол-во врагов в волне
//         [SerializeField] private float _spawnRate = 0f; //Скорость спавна
//
//         public GameObject GetRandomEnemyPrefab()
//         { return _enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Length)]; }
//     
//         public float GetEnemyStrengthMulti()
//         { return _enemyStrengthMultiplier; }
//
//         public int GetEnemiesInWave()
//         { return _enemiesInWave; }
//
//         public float GetWaveSpawnRate()
//         { return _spawnRate; }
//
//         public string GetWaveName()
//         { return _waveName; }
//     }
// }