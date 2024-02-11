using UnityEngine;

namespace CowMilking.SO
{
    public abstract class SpawnableInfo : ScriptableObject
    {
        public GameObject Prefab;
        public int Cost;
    }
}