using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "CowInfo", menuName = "ScriptableObject/Spawnable/CowInfo")]
    public class CowInfo : SpawnableInfo
    {
        public float DelayBetweenSkill;
    }
}