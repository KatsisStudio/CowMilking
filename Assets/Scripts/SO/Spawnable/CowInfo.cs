using CowMilking.Character.Player;
using CowMilking.DialogueSystem;
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
        public int BaseHealth;

        public ElementType Element;
        public bool IsStartingCow;

        public CowInfo NextCow;
        public Conversation Conversation;
        public Sprite FinalCG;

        [Header("Grass")]
        public bool EatGrass;
        public float DelayBetweenGrassEating;

        [Header("Bullet")]
        public bool FireBullet;
        public int Damage;
        public Color Color;
        public float DelayBetweenBullets;
        public float SlowDuration;
    }
}