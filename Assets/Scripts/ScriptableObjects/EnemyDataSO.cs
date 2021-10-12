using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Create EnemyData", fileName = "EnemyDataSO", order = 0)]
    public class EnemyDataSO : ScriptableObject
    {
        public Material EnemyMaterial;
        public int EnemyHealth;
        public float EnemySpeed;
    }
}
