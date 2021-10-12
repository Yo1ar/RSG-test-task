using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Create BulletData", fileName = "BulletDataSO", order = 0)]
    public class BulletDataSO : ScriptableObject
    {
        public float BulletSpeed;
    }
}