using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/Create PlayerData", fileName = "PlayerData", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        public Material PlayerMaterial;
        public int PlayerMaxHealth;
        public int PlayerPower;
        public float PlayerReloadSpeed;
        public float MoveSpeed;
    }
}
