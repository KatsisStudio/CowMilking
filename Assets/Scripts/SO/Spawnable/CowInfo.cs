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
        public float DelayBetweenSkill;
        public Sprite Sprite;

        public ElementType Element;
        public bool IsStartingCow;
    }
}