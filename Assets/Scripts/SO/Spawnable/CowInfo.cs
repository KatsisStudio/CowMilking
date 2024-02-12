using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "CowInfo", menuName = "ScriptableObject/Spawnable/CowInfo")]
    public class CowInfo : SpawnableInfo
    {
        public string Key;
        public string Name;
        public float DelayBetweenSkill;
        public Sprite Sprite;
    }
}