using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "WaveInfo", menuName = "ScriptableObject/WaveInfo")]
    public class WaveInfo : ScriptableObject
    {
        public EnemyInfo[] Enemies;

        public int EnemyCount;
    }
}