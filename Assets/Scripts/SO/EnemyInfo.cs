using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObject/EnemyInfo")]
    public class EnemyInfo : ScriptableObject
    {
        public GameObject Prefab;

        public float Speed;
    }
}