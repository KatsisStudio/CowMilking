using CowMilking.Character.Player;
using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "CowInfo", menuName = "ScriptableObject/Spawnable/CowInfo")]
    public class CowInfo : SpawnableInfo
    {
        [Header("Cow Stuff")]
        public string Key;
        public string Name;
        public Sprite Sprite;

        public ElementType Element;
        public bool IsStartingCow;

        public CowInfo NextCow;

        [Header("Skill Info")]
        public float DelayBetweenSkill;
        public int Damage;
    }
}